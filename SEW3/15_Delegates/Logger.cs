using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Delegates
{
    internal class Logger
    {
        public delegate void LogHandler(string message, int priority);

        public event LogHandler? LogReceived;
        public event EventHandler? LogReceivedEH;

        public void AddLog(string message, int priority)
        {
            // Event auslösen
            if (LogReceived != null)    // wenn kein Eventhandler angemeldet ist, dann null
            {
                LogReceived(message, priority); // Event mit den übergebenen Parametern auslösen
            }

  
            if (LogReceivedEH != null)
            {
                LogReceivedEH(this, new LogEventArgs(message, priority)); // Event mit den übergebenen Parametern auslösen
            }


        }
    }
}
