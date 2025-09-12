
using System.IO;


namespace CS142_HerbariumLibrary
{
    public class Herbarium_old
    {
        public static void Generate()
        {
            // PowerPoint-Datei laden
            using FileStream inputStream = new FileStream("HerbariumTemplate.pptx", FileMode.Open, FileAccess.Read);
            using IPresentation presentation = Presentation.Open(inputStream);

            // Neue Folie mit Layout "Two Content" hinzufügen
                       
            var master = presentation.Masters[0];
            ILayoutSlide? customLayout = master.LayoutSlides.FirstOrDefault(layout => layout.Name == "Herbarium2");


            ISlide slide = presentation.Slides.Add(customLayout);

            // ─────────────────────────────────────────────
            // 1) Titelplatzhalter finden und Text setzen
            // ─────────────────────────────────────────────
            //IShape? title = slide.Shapes.FirstOrDefault(s => s..Type == PlaceholderType.Title);
            //((Syncfusion.Presentation.Drawing.Shape)(slide.Shapes[0] as IShape)).PlaceholderFormat
            //ISlideItem? title = slide.Shapes.FirstOrDefault(s => (s as IShape).PlaceholderFormat.Type == PlaceholderType.Title);

            foreach (IShape shape in slide.Shapes)
            {
                // Modify the shape properties (text, size, hyperlinks, etc.)
                ModifySlideElements(shape);
            }
            //if (title?.Title != null)
            //{
            //    //title.Title.Text = "Dies ist der Titel";          // Kurzform
            //    // title.TextBody.AddParagraph("Dies ist der Titel"); // Alternative :contentReference[oaicite:1]{index=1}
            //}

            //// ─────────────────────────────────────────────
            //// 2) Zwei Body-Platzhalter finden und befüllen
            //// ─────────────────────────────────────────────
            //var bodies = slide.Shapes
            //                  .Where(s => s.PlaceholderFormat?.Type == PlaceholderType.Body)
            //                  .ToList();                             // Body, CenterBody, VerticalBody u. a. sind möglich :contentReference[oaicite:2]{index=2}

            //if (bodies.Count >= 2 && bodies[0].TextBody != null && bodies[1].TextBody != null)
            //{
            //    bodies[0].TextBody.Text = "Inhalt links";
            //    bodies[1].TextBody.Text = "Inhalt rechts";
            //}

            // Präsentation speichern
            using FileStream outputStream = new FileStream("Ergebnis.pptx", FileMode.Create, FileAccess.Write);
            presentation.Save(outputStream);

        }

        private static void ModifySlideElements(IShape shape)
        {
            switch (shape.SlideItemType)
            {

                case SlideItemType.Placeholder:
                    {
                        // Modify text if present in the placeholder                        
                        ModifyTextPart(shape.TextBody);                        
                        break;
                    }
            }
        }


        private static void ModifyTextPart(ITextBody textBody)
        {
            textBody.Text = "Hallo";
            // Iterate through paragraphs in the text body
            //foreach (IParagraph paragraph in textBody.Paragraphs)
            //{
            //    // Iterate through text parts and modify the text
            //    foreach (ITextPart textPart in paragraph.TextParts)
            //    {
            //        textPart.Text = "Adventure Works";
            //    }
            //}
        }
    }
}
