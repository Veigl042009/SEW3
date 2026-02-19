using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue8_Maut
{
    internal class Truck : Vehicle
    {

        public Truck(string licensePlate, double weight) : base(licensePlate, weight)
        {
            // Aufruf des Konstruktors der Basisklasse Vehicle,
            // um die Eigenschaften LicensePlate und Weight zu initialisieren
        }
        public override double CalculateToll()
        {
            // Mautberechnung für LKWs, Maut = Grundmaut + 0,02 €/kg + 10 € Aufschlag bei > 10 t
            double toll = base.CalculateToll() + 0.02 * Weight;

            // Aufschlag wenn Gewicht über 10.000 kg (10 Tonnen)
            if (Weight > 10000)
                toll += 10;

            return toll;
        }
    }
    
}
