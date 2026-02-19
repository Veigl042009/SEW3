using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue8_Maut
{
    internal class Tollstation
    {
        // Name der Mautstation
        public string Name { get; set; }

        // Gesamteinnahmen
        private double totalToll = 0;

        public Tollstation(string name)
        {
           Name = name;
        }

        // Ein Fahrzeug fährt durch → Maut wird berechnet und addiert
        // im v werden Fahrzeugspezifische Informationen übergeben,
        // damit die Maut korrekt berechnet werden kann
        public void VehiclePasses(Vehicle v)
        {
            double toll = v.CalculateToll();
            totalToll += toll;

            Console.WriteLine($"{v} --> Maut: {toll:F2} Euro");
        }

        // Getter für Gesamteinnahmen
        public double TotalToll => totalToll;
    }

}

