using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue8_Maut
{
    internal class Vehicle
    {
        public string LicensePlate { get; set; } // Kennzeichen des Fahrzeugs

        public double Weight { get; set; } // Gewicht des Fahrzeugs in Kg

            public Vehicle(string licensePlate, double weight)
            {
                LicensePlate = licensePlate;
                Weight = weight;
            }

        public virtual double CalculateToll()
        {
            // Standardmautberechnung, kann in abgeleiteten Klassen überschrieben werden
            return 5.0; // Beispiel: Pauschalbetrag für alle Fahrzeuge
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Kennzeichen={LicensePlate}, Gewicht={Weight} kg]";

            // Überschreibt die ToString-Methode, um eine benutzerfreundliche Darstellung des Fahrzeugs zu bieten
        }
    }
}
