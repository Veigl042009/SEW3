using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Exceptions
{
    internal class IT23Exception : Exception
    {
        public IT23Exception(string message) : base(message)
        {
        }
    }
}
