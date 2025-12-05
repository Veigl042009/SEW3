using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CallByReference
{
    internal class Calculator
    {       
        // Methodenüberladung --> 3 Methoden mit gelichem Namen, unterscheiden sich anhand der Methodensignatur
        public static int CalculateDouble(int x)
        {
            int result = x * 2;
            return result;
        }

        public static void CalculateDouble(int x, out int result)
        {
            result = x * 2;
        }
        public static void CalculateDouble(ref int x)
        {
            x *= 2;
        }

    }

}
