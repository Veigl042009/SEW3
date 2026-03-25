using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue8_Maut
{
    internal class Car : Vehicle
    {
        public Car(string licensePlate, double weight) : base(licensePlate, weight)
        {
            // Aufruf des Konstruktors der Basisklasse Vehicle,
            // um die Eigenschaften LicensePlate und Weight zu initialisieren
        }

        public override double CalculateToll()
        {
            // Mautberechnung für Autos, z.B. basierend auf dem Gewicht
            return base.CalculateToll() + (Weight * 0.01); // Beispiel: Grundgebühr + Gewichtszuschlag
        }


    }
}
