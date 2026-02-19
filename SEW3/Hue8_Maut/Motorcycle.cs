using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue8_Maut
{
    internal class Motorcycle : Vehicle
    {
        // Konstruktor
        public Motorcycle(string licensePlate, double weight) : base(licensePlate, weight) { }

        // Motorräder zahlen nur die Grundmaut
        public override double CalculateToll()
        {
            return base.CalculateToll();
        }

    }
}
