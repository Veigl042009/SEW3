using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace HÜ05_01
{
    internal class Schwein
    {
        private double weight;
        private int MFA;
        private bool AmaGuetesiegel;
        private double pricePerKg;
        public Schwein(double weight, int MFA, bool AmaGuetesiegel, double pricePerKg)
        {
            this.weight = weight;
            this.MFA = MFA;
            this.AmaGuetesiegel = AmaGuetesiegel;
            this.pricePerKg = pricePerKg;
        }
        public double getWeight
        {                           // Gibt das Gewicht des Schweins zurück
            get { return weight; }
        }
        public double CalculatePricePerKG()     //Berechnet den Preis pro KG Schwein
        {
            double PricePerKG = pricePerKg;
            PricePerKG += AMAZuschlag();
            PricePerKG += Gewichtszuschlag();
            PricePerKG += Optimalkorridor();        // von 90 bis 102 kg und MFA von 58 bis 61
            PricePerKG += MFAZuschlag();
            return PricePerKG;
        }
        public double CalculatePricePerPig()
        {
            return CalculatePricePerKG() * weight;
        }
        public double AMAZuschlag()
        {

            if (AmaGuetesiegel && weight >= 80 && weight <= 102 && MFA >= 55 && MFA <= 64)
            {
                return 0.067;
            }
            else
            {
                return 0.0;

            }
        }
        public double Gewichtszuschlag()
        {
            if (weight < 60)
            {
                return -0.3;
            }
            if (weight >= 60 && weight < 70)
            {
                return -0.29;
            }
            if (weight >= 70 && weight < 72)
            {
                return -0.19;
            }
            if (weight >= 72 && weight < 73)
            {
                return -0.15;
            }
            if (weight >= 73 && weight < 74)
            {
                return -0.14;
            }
            if (weight >= 74 && weight < 75 || weight > 113)
            {
                return -0.12;
            }
            if (weight >= 75 && weight < 76)
            {
                return -0.10;
            }
            if (weight <= 113 && weight > 112)
            {
                return -0.09;
            }
            if (weight >= 76 && weight < 77 || weight <= 112 && weight > 111)
            {
                return -0.08;
            }
            if (weight <= 111 && weight > 110)
            {
                return -0.07;
            }
            if (weight >= 77 && weight < 78 || weight <= 109 && weight > 110)
            {
                return -0.06;
            }
            if (weight >= 78 && weight < 79 || weight <= 108 && weight > 109)
            {
                return -0.05;
            }
            if (weight >= 79 && weight < 80 || weight <= 107 && weight > 108)
            {
                return -0.04;
            }
            if (weight >= 80 && weight < 81)
            {
                return -0.03;
            }
            if (weight >= 81 && weight < 82 || weight <= 106 && weight > 107)
            {
                return -0.02;
            }
            return 0.0;
        }
        public double Optimalkorridor()
        {
            if (weight >= 90 && weight <= 102 && MFA >= 58 && MFA <= 61)
            {
                return 0.02;
            }
            return 0.0;
        }
        public double MFAZuschlag()
        {
            Dictionary<int, double> mfaZuschlaege = new Dictionary<int, double>() // Wenn man den MFA Wert hat, bekommt man den entsprechenden Zuschlag
            {
                { 50, -0.21 },      
                { 51, -0.19 },
                { 52, -0.16 },
                { 53, -0.13 },
                { 54, -0.09 },
                { 55, -0.05 },
                { 56,  0.00 },
                { 57,  0.05 },
                { 58,  0.09 },
                { 59,  0.13 },
                { 60,  0.16 },
                { 61,  0.19 },
                { 62,  0.21 }
            };


            if (MFA < 50)
                return -0.22;

            if (MFA > 62)
                return 0.22;

            return mfaZuschlaege[MFA];
        }
    }
}
