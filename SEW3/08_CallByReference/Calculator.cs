using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CallByReference
{
    internal class Calculator
    {
        public static int CalculateDouble(int x)
        {
            return x * 2;
        }

        public static void CalculateDoubleRef(int x, out int result)
        {
            result = x * 2;
        }
        public static void CalculateDoubleInRef(ref int x)
        {
            x *= 2;
        }

    }

}
