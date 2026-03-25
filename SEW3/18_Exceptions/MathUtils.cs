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
            if (list.Count > 100)
            {
                throw new IT23Exception("Das ist uns zu viel. Das schaffen wir nicht im Kopf");
            }
            else if (list.Count > 0)
            {
                return list.Average();
            }
            else
            {
                throw new ArgumentException("Anzahl der Elemente in der Liste: 0. Mittelwertberechnung nicht möglich.");
                //throw new Exception("Anzahl der Elemente in der Liste: 0. Mittelwertberechnung nicht möglich.");
            }


        }
    }
}
