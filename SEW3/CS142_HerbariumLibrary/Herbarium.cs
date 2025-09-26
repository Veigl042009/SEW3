using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Vml;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System.Text;
using System.Xml.Linq;
using BlipFill = DocumentFormat.OpenXml.Presentation.BlipFill;
using Directory = System.IO.Directory;
using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
using NonVisualGroupShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeDrawingProperties;
using NonVisualGroupShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeProperties;
using Path = System.IO.Path;
using Picture = DocumentFormat.OpenXml.Presentation.Picture;
using Shape = DocumentFormat.OpenXml.Presentation.Shape;
using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;

namespace FJHerbariumLibrary
{
    public class Herbarium
    {
        public void Generate(string templatePath, string outputFolder, string nameOfMetadata, string pathToImages)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Template-Datei nicht gefunden.", templatePath);
            if (!Directory.Exists(outputFolder))
            {
                throw new DirectoryNotFoundException("Output-Ordner nicht gefunden: " + outputFolder);
            }
            if(!Directory.Exists(pathToImages))
            {
                throw new DirectoryNotFoundException("Bilder-Ordner nicht gefunden: " + pathToImages);
            }

                // Ausgangs-Template kopieren
            string outputPptx = Path.Combine(outputFolder, "Herbarium.pptx");
            string outputPdf = Path.Combine(outputFolder, "Herbarium.pdf");
            File.Copy(templatePath, outputPptx, true);

            using (PresentationDocument doc = PresentationDocument.Open(outputPptx, true))
            {
                PresentationPart? presPart = doc.PresentationPart;
                if (presPart == null)
                    throw new InvalidOperationException("PresentationPart ist null.");

                Presentation? pres = presPart.Presentation;
                if (pres == null)
                    throw new InvalidOperationException("Presentation ist null.");                

                List<Plant> plants = ReadMetaData(pathToImages, nameOfMetadata);
                RefinePlantsWithImages(plants, pathToImages);

                foreach (var plant in plants)
                {
                    GenerateSlide(presPart, pres, plant);
                }

                pres.Save();

                //PDF-Generierung mit OpenXml nicht möglich
                //GeneratePdf(pres, outputPdf);
            }
        }       

        private static void RefinePlantsWithImages(List<Plant> plants, string pathToImages)
        {
            foreach(var plant in plants)
            {
                if (!plant.Id.HasValue)
                    throw new ArgumentException("Plant.Id is null");
                string idAsString = plant.Id.Value.ToString("D3");                
                string[] extensions = { ".jpg", ".jpeg", ".png", ".gif" };
                foreach (string ext in extensions)
                {
                    int indexOfImage = 1;
                    while (true)
                    {
                        string pathToImage = Path.Combine(pathToImages, $"{idAsString}_{indexOfImage}{ext}");
                        if (!File.Exists(pathToImage))
                        {
                            break;
                        }
                        plant.Images.Add(pathToImage);
                        indexOfImage++;
                    }
                }
            }            
        }       

        private static List<Plant> ReadMetaData(string pathToImages, string fileNameOfMetadata)
        {
            string pathToMetaData = Path.Combine(pathToImages, fileNameOfMetadata);
            if (!File.Exists(pathToMetaData))
                throw new FileNotFoundException("Metadaten-Datei nicht gefunden.", pathToMetaData);
            var plants = new List<Plant>();
            foreach (var line in File.ReadLines(pathToMetaData))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(';');
                if (parts.Length < 7)
                {
                    throw new FormatException($"Ungültiges Format in Metadaten-Datei.{line}");
                }

                var plant = new Plant
                {
                    Id = int.Parse(parts[0].Trim()),
                    NameGerman = parts[1].Trim(),
                    NameLatin = parts[2].Trim(),
                    FamilyGerman = parts[3].Trim(),
                    FamilyLatin = parts[4].Trim(),
                    Date = DateOnly.Parse(parts[5].Trim()),
                    Location = parts[6].Trim()
                };
                plants.Add(plant);
            }
            return plants;
        }

        private static void GenerateSlide(PresentationPart presPart, Presentation pres, Plant plant)
        {           

            // Master holen (erster genügt oft)
            SlideMasterPart? master = presPart.SlideMasterParts.FirstOrDefault();
            if (master == null)
                throw new InvalidOperationException("Kein SlideMasterPart gefunden.");

            
            string layout = $"Herbarium{plant.Images.Count}";
            // Layout "Herbarium2" suchen
            var layoutPart = master.SlideLayoutParts
                                   .FirstOrDefault(lp => lp.SlideLayout?.CommonSlideData?.Name?.Value == layout);

            if (layoutPart == null)
                throw new Exception($"Layout '{layout}' nicht gefunden!");

            // Neue Folie anlegen + Layout referenzieren
            SlidePart slidePart = presPart.AddNewPart<SlidePart>();
            slidePart.Slide = new Slide(new CommonSlideData(new ShapeTree()));

            // Verbindung zum Layout
            slidePart.AddPart(layoutPart);

            // Pflicht-Struktur ShapeTree auffüllen
            var shapeTree = slidePart!.Slide!.CommonSlideData!.ShapeTree;
            shapeTree!.Append(new NonVisualGroupShapeProperties(
                new NonVisualDrawingProperties() { Id = 1U, Name = "" },
                new NonVisualGroupShapeDrawingProperties(),
                new ApplicationNonVisualDrawingProperties()
            ));
            shapeTree.Append(new GroupShapeProperties());

            // -----------------------
            // Layout-Shapes kopieren
            // -----------------------
            var layoutShapes = layoutPart!.SlideLayout!.CommonSlideData!.ShapeTree!.Elements<DocumentFormat.OpenXml.Presentation.Shape>();
            foreach (var shape in layoutShapes)
            {
                // Shape klonen und der Folie hinzufügen
                var clonedShape = (DocumentFormat.OpenXml.Presentation.Shape)shape.CloneNode(true);
                slidePart!.Slide!.CommonSlideData!.ShapeTree!.Append(clonedShape);
            }

            // Neue SlideId bestimmen
            uint newId;
            if (pres.SlideIdList == null)
            {
                pres.SlideIdList = new SlideIdList();
                newId = 256; // Startwert für die erste Folie
            }
            else
            {
                newId = pres.SlideIdList.Elements<SlideId>()
                        .Select(s => (uint)s.Id!)
                        .DefaultIfEmpty(255U) // falls keine Elemente drin
                        .Max() + 1;
            }

            if (pres.SlideIdList == null)
                pres.SlideIdList = new SlideIdList();

            pres.SlideIdList.Append(new SlideId
            {
                Id = newId,
                RelationshipId = presPart.GetIdOfPart(slidePart)
            });

            // Shapes im Layout/Slide durchgehen und Text einsetzen
            
            ModifySlideElements(slidePart, plant);
        }

        private static void SetTextByDescriptionPlaceholder(SlidePart slidePart, string placeholderText, string newText)
        {
            // Slide als XML-String holen
            string slideXml = slidePart.Slide.OuterXml;

            // In XDocument laden
            XDocument xdoc = XDocument.Parse(slideXml);

            XNamespace p = "http://schemas.openxmlformats.org/presentationml/2006/main";
            XNamespace a = "http://schemas.openxmlformats.org/drawingml/2006/main";

            // Shape mit Text "Beschreibung" finden
            var shape = xdoc.Descendants(p + "sp")
                            .FirstOrDefault(sp => sp.Descendants(a + "t")
                                                     .Any(t => t.Value == placeholderText));
            if(shape == null)
            {
                throw new Exception($"Placeholder mit Text '{placeholderText}' nicht gefunden.");
            }


            var t = shape.Descendants(a + "t")
                         .FirstOrDefault(t => t.Value == placeholderText);
            if (t != null)
                t.Value = newText;

            // Änderungen zurück in SlidePart schreiben
            slidePart.FeedData(new MemoryStream(Encoding.UTF8.GetBytes(xdoc.ToString())));
        }


        public static void SetImageByDescriptionPlaceholder(SlidePart slidePart, string placeholderText, string pathToImage)
        {
            // 1. Den Shape finden, dessen TextBody den PlaceholderText enthält
            Shape? placeholderShape = slidePart.Slide.Descendants<Shape>()
                .FirstOrDefault(s => s.TextBody != null &&
                                     s.TextBody.Descendants<DocumentFormat.OpenXml.Drawing.Text>()
                                               .Any(t => t.Text == placeholderText));

            if (placeholderShape == null)
            {
                throw new Exception($"Placeholder mit Text '{placeholderText}' nicht gefunden.");
            }

            // 2. Alten TextBody entfernen
            placeholderShape.TextBody?.Remove();

            int rotation = 0;
            ImagePart imagePart;
            // 3. Bild als ImagePart hinzufügen
            if (pathToImage.EndsWith(".jpg")  || pathToImage.EndsWith(".jpeg"))
            {                
                var directories = MetadataExtractor.ImageMetadataReader.ReadMetadata(pathToImage);
                ExifIfd0Directory? exifIfd0 = directories.OfType<ExifIfd0Directory>().FirstOrDefault();                
                int orientation = 0;

                if (exifIfd0 != null && exifIfd0.ContainsTag(ExifDirectoryBase.TagOrientation))
                {
                    orientation = exifIfd0.GetInt32(ExifDirectoryBase.TagOrientation);
                }

                switch (orientation)
                {
                    case 1 or 2:
                        rotation = 0;
                        // Normal, nichts tun
                        break;
                    case 3 or 4:
                        rotation = 180;
                        break;
                    case 5 or 6:
                        rotation = 90;
                        break;
                    case 7 or 8:
                        rotation = 270;
                        break;
                    default:
                        // Unbekannte Orientation, nichts tun
                        break;
                }
                imagePart = slidePart.AddImagePart(ImagePartType.Jpeg);

            } else if(pathToImage.EndsWith(".png"))
            {
                imagePart = slidePart.AddImagePart(ImagePartType.Png);
            } else if(pathToImage.EndsWith(".gif"))
            {
                imagePart = slidePart.AddImagePart(ImagePartType.Gif);
            } else
            {
                imagePart = slidePart.AddImagePart(ImagePartType.Bmp);
            }

                using (var stream = File.OpenRead(pathToImage))
                {
                    imagePart.FeedData(stream);
                }

            string rId = slidePart.GetIdOfPart(imagePart);

            // 4. Position und Größe vom Originalplaceholder übernehmen
            var off = placeholderShape.ShapeProperties?.Transform2D?.Offset ?? new DocumentFormat.OpenXml.Drawing.Offset() { X = 0, Y = 0 };
            var ext = placeholderShape.ShapeProperties?.Transform2D?.Extents ?? new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 1000000, Cy = 1000000 };            

            // 5. NonVisualPictureProperties erstellen
            var nvPicPr = new NonVisualPictureProperties(
                new NonVisualDrawingProperties() { Id = placeholderShape.NonVisualShapeProperties?.NonVisualDrawingProperties?.Id ?? 2U, Name = "Bild" },
                new NonVisualPictureDrawingProperties(new DocumentFormat.OpenXml.Drawing.PictureLocks() { NoChangeAspect = false }),
                new ApplicationNonVisualDrawingProperties()
            );

            // 6. BlipFill erstellen
            var blipFill = new BlipFill(
                new DocumentFormat.OpenXml.Drawing.Blip() { Embed = rId },
                new DocumentFormat.OpenXml.Drawing.Stretch(new DocumentFormat.OpenXml.Drawing.FillRectangle())
            );

            var blipExtensionList1 = new DocumentFormat.OpenXml.Drawing.BlipExtensionList();
            var blipExtension1 = new DocumentFormat.OpenXml.Drawing.BlipExtension()
            {
                Uri = Guid.NewGuid().ToString(),
            };
            var useLocalDpi1 = new DocumentFormat.OpenXml.Office2010.Drawing.UseLocalDpi()
            {
                Val = false
            };
            blipFill.Blip!.Append(blipExtensionList1);
            useLocalDpi1.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2010/main");
            blipExtension1.Append(useLocalDpi1);
            blipExtensionList1.Append(blipExtension1);

            // 7. ShapeProperties erstellen
            var spPr = new ShapeProperties(
                new DocumentFormat.OpenXml.Drawing.Transform2D(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = off.X, Y = off.Y },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = ext.Cx, Cy = ext.Cy }
                )
                { Rotation = rotation * 60000},  // Rotation wird 60000stel angegeben --> 90 * 60000
                new DocumentFormat.OpenXml.Drawing.PresetGeometry(
                    new DocumentFormat.OpenXml.Drawing.AdjustValueList()
                    )
                    {
                        Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle
                    }
            );

            // 8. Neues Picture erstellen
            var pic = new Picture(nvPicPr, blipFill, spPr);

            // 9. Placeholder-Shape durch Picture ersetzen
            if (placeholderShape.Parent != null)
            {
                placeholderShape.Parent.InsertAfter(pic, placeholderShape);
                placeholderShape.Remove();
            }

            slidePart.Slide.Save();
        }


        private static void ModifySlideElements(SlidePart slidePart, Plant plant)
        {            
            SetTextByDescriptionPlaceholder(slidePart, "NameGerman", plant.NameGerman!);
            SetTextByDescriptionPlaceholder(slidePart, "NameLatin", plant.NameLatin!);
            SetTextByDescriptionPlaceholder(slidePart, "FamilyGerman", plant.FamilyGerman!);
            SetTextByDescriptionPlaceholder(slidePart, "FamilyLatin", plant.FamilyLatin!);
            SetTextByDescriptionPlaceholder(slidePart, "Location", plant.Location!);
            SetTextByDescriptionPlaceholder(slidePart, "Date", plant.Date!.ToString());

            int index = 1;
            foreach (var pathToImage in plant.Images)
            {
                SetImageByDescriptionPlaceholder(slidePart, $"Image{index}", pathToImage);
                index++;
            }                
        }
       
    }
}
