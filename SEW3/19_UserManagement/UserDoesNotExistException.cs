using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_UserManagement
{
    internal class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException(int benutzerId) : base($"Benutzer mit Id: {benutzerId} existiert nicht.")
        {

        }
    }
}
