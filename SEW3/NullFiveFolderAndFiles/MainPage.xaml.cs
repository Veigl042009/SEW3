using CommunityToolkit.Maui.Storage;
namespace NullFiveFolderAndFiles
{
    public partial class MainPage : ContentPage 
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private async void btnFolderClicked(object sender, EventArgs e)
        {
           FolderPickerResult result = await FolderPicker.Default.PickAsync();  // async Methoden brauchen: await und async in der Methode
            if(result != null && result.Folder != null) //Cancel durch Benutzer
            {
                string path = result.Folder.Path;
                lbResultFolder.Text = path;
            }
            
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            PickOptions options = new PickOptions();
            options.FileTypes = FilePickerFileType.Images;
            options.PickerTitle = "Wähle ein schönes Bild aus";

            FileResult result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                string filepath = result.FullPath;
                lbResultFolder.Text = filepath;
            }

        }
    }
}
