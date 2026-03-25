namespace _19_UserManagement
{
    public class UserManagement
    {
        public static string GetUserProfile(int benutzerId)
        {
            return LadeBenutzer(benutzerId);

        }
        public static void SendEmail(int benutzerId)
        {
           string user = LadeBenutzer(benutzerId);
            Console.WriteLine("Email gesendet");
        }
        private static string LadeBenutzer(int benutzerId)
        {
            // Simulierte Datenbank
            if (benutzerId == 1)
            {
                return "Max Mustermann,";
            }
            else if (benutzerId == 2)
            {
                return "Thomas Riegler";
            }
            throw new UserDoesNotExistException(benutzerId);

        }
    }
}
