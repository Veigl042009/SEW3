using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Sierpinski
{
    internal class STriangle
    {
        public SPoint A { get; set; }
        public SPoint B { get; set; }
        public SPoint C { get; set; }

        public STriangle(SPoint a, SPoint b, SPoint c)
        {
            A = a;
            B = b;
            C = c;
        }

        public SPoint MidAB
        {
            get 
            {
                return new SPoint((A.X + B.X) / 2, (A.Y + B.Y) / 2);
            }
        }

        public SPoint MidBC
        {
            get 
            {
                return new SPoint((B.X + C.X) / 2, (B.Y + C.Y) / 2);
            }
        }

        public SPoint MidCA
        {
            get 
            {
                return new SPoint((C.X + A.X) / 2, (C.Y + A.Y) / 2);
            }
        }
    }
}
