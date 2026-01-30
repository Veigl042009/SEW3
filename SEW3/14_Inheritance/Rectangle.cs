using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Inheritance
{
    internal class Rectangle( int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;

        /*public Rectangle(int x, int y)
        {
            X = x;                          das ist zuviel arbeit
            Y = y;
        }*/

        public int Area()
        {
            return X * Y;
        }

        public override bool Equals(object? obj)
        {
            // dynamischer Datentyp von obj ist Rectangle
            // statischer Datentyp von obj ist object

            if (obj == null)
            {
                return false;
            }
            if (obj is Rectangle)
            {
                Rectangle other = (Rectangle)obj;
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }
    }
}
