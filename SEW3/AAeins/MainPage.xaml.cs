using AANotizManagerLibrary;

namespace AAeins
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private NotizManager notizManager;

        public MainPage()
        {
            InitializeComponent();
            notizManager = new NotizManager();
        }

        private async void SpeichernButton_Clicked(object sender, EventArgs e)
        {
            // Text aus dem Editor holen
            notizManager.NotizText = NotizEditor?.Text ?? string.Empty;

            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Speicherort auswählen",
                    FileTypes = null // Allow all file types by setting to null
                });

                if (result != null && !string.IsNullOrWhiteSpace(result.FullPath))
                {
                    bool erfolgreich = notizManager.SpeichereInDatei(result.FullPath);
                    if (erfolgreich)
                    {
                        await DisplayAlert("Erfolg", "Notiz gespeichert!", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Fehler", "Speichern fehlgeschlagen!", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Abbruch", "Kein gültiger Speicherort ausgewählt.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fehler", $"Speichern fehlgeschlagen: {ex.Message}", "OK");
            }
        }

        private async void ZaehleWoerterButton_Clicked(object sender, EventArgs e)
        {
            notizManager.NotizText = NotizEditor.Text ?? string.Empty;
            int anzahl = notizManager.ZaehleWoerter();
            await DisplayAlert("Wörter zählen", $"Ihre Notiz enthält {anzahl} Wörter.", "OK");
        }
    }
}
