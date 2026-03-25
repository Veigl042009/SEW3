using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_FuncAction
{
    internal class Logger
    {
       // public delegate void LogHandler(string message, int priority);
       // public event LogHandler? LogReceived;

        public event Action<string, int>? LogReceived; // Action Delegate, da void Rückgabewert und zwei Parameter

        public void AddLog(string message, int priority)
        {
            // Event auslösen
            if (LogReceived != null)    // wenn kein Eventhandler angemeldet ist, dann null
            {
                LogReceived(message, priority); // Event mit den übergebenen Parametern auslösen
            }
        } 
    }
}
