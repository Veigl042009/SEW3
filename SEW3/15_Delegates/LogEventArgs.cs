using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Delegates
{
    internal class LogEventArgs : EventArgs
    {
  
        public string Message { get; set; }

        public int Priority { get; set; }

        public LogEventArgs(string message, int priority) : base()
        {
            Message = message;
            Priority = priority;
        }
    }
}
