using _19_UserManagement;
namespace Twenty_UserManagement
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoadProfileClicked(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(UserIdEntry.Text);
                string profile = UserManagement.GetUserProfile(id);
                OutputLabel.Text = $"Profil: {profile}";
            }
            catch (Exception ex)
            {
                OutputLabel.Text = ex.Message;
            }
        }

        private void OnSendEmailClicked(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(UserIdEntry.Text);
                UserManagement.SendEmail(id);
                OutputLabel.Text = "E-Mail wurde gesendet.";
            }
            catch (Exception ex)
            {
                OutputLabel.Text = ex.Message;
            }
        }
    }
}
