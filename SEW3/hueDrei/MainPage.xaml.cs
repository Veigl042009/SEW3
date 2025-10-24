using CommunityToolkit.Maui.Storage;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using FJHerbariumLibrary;
using MetadataExtractor.Util;




namespace hueDrei {
    public partial class MainPage : ContentPage {


        public MainPage() {
            InitializeComponent();
        }
        string templatePath = "";
        string outputFolder = "";
        string nameOfMetaData = "";
        string pathToImages = "";
        private async void bOutputPicker_Clicked(object sender, EventArgs e) {
            FolderPickerResult result = await FolderPicker.Default.PickAsync();
            if (result.IsSuccessful) {
                outputFolder = result.Folder.Path;
                bOutputPicker.Text = "Ausgabeordner: " + outputFolder;
            } else {
                outputFolder = "";
                bOutputPicker.Text = "Falsche Eingabe! Erneut probieren:";
            }


        }


        private async void bTemplatePicker_Clicked(object sender, EventArgs e) {
            PickOptions options = new PickOptions() { PickerTitle = "Wählen Sie Ihre PowerPoint aus!", FileTypes = null };
            FileResult result = await FilePicker.Default.PickAsync(options);

            if (result != null && result.FileName.EndsWith("pptx")) {

                templatePath = result.FullPath;
                bTemplatePicker.Text = "Template ausgewählt: " + result.FileName;
            } else if (result != null) {
                templatePath = "";
                bTemplatePicker.Text = "Das Template muss eine PowerPoint Datei sein! Erneut probieren:";
            } else {
                templatePath = "";
                bTemplatePicker.Text = "Keine Datei gewählt. Erneut probieren:";
            }
        }

        private async void bMetaDataPicker_Clicked(object sender, EventArgs e) {
            PickOptions options = new PickOptions() { PickerTitle = "Wählen Sie Ihre Metadaten-Datei aus!", FileTypes = null };
            FileResult result = await FilePicker.Default.PickAsync(options);
            if (result != null && result.FileName.EndsWith("txt")) {
                nameOfMetaData = result.FullPath;
                bMetaDataPicker.Text = "Metadaten-Datei ausgewählt: " + result.FileName;
            } else if (result != null) {
                nameOfMetaData = "";
                bMetaDataPicker.Text = "Die Metadaten-Datei muss eine .txt Datei sein! Erneut probieren:";
            } else {
                nameOfMetaData = "";
                bMetaDataPicker.Text = "Keine Datei gewählt. Erneut probieren:";
            }
        }
        private async void bImagesPicker_Clicked(object sender, EventArgs e) {
            FolderPickerResult result = await FolderPicker.Default.PickAsync();
            if (result.IsSuccessful) {
                pathToImages = result.Folder.Path;
                bImagesPicker.Text = "Ausgewählter Bilder-Ordner: " + pathToImages;
            } else {
                pathToImages = "";
                bImagesPicker.Text = "Falsche Eingabe! Erneut probieren:";
            }
        }

        private void bCreateHerbarium_Clicked(object sender, EventArgs e) {
            if (templatePath != "" && outputFolder != "" && nameOfMetaData != "" && pathToImages != "") {
                Herbarium herbarium = new Herbarium();
                herbarium.Generate(templatePath, outputFolder, nameOfMetaData, pathToImages);
                DisplayAlert("Erfolg!", "Das Herbarium wurde erstellt!", "OK");

            } else {
                DisplayAlert("Fehler!", "Bitte alle Eingaben tätigen und kontrollieren!", "OK");
            }
        }


    }
}
