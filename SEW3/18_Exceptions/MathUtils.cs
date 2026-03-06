using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Exceptions
{
    internal class MathUtils
    {
        public static double ClaculateAverage(List<int> list)
        {
            if (list.Count > 0)
            {
                return list.Average();
            }
            else 
            {
                // eine Exception werfen
            }


        }
    }
}
