using HÜ05_01;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HÜ05_01
{
    internal class PigRevenue
    {
        public static double PriceOfTheHerd()
        {
            double entirePriceHerd = 0;
            List<Schwein> pig = GetPigs();      // Macht die Liste der Schweine
            foreach (Schwein e in pig)
            {
                entirePriceHerd += e.CalculatePricePerPig();    // Gesamten Preis der Herde berechnen
            }
            entirePriceHerd += MengenZuschlag();
            return Math.Round(entirePriceHerd, 2);
        }
        public static int CountValidPigs()      // Zählt die Anzahl der Schweine über 70 kg
        {
            List<Schwein> schwein = PigRevenue.GetPigs();
            int totalPigs = schwein.Count;
            foreach (Schwein e in schwein)
            {
                if (e.getWeight <= 70)
                {
                    totalPigs--;
                }
            }
            return totalPigs;
        }
        public static double MengenZuschlag()
        {
            int totalPigs = CountValidPigs();
            double zuschlag = 0;

            for (int i = 21; i <= totalPigs && i <= 58; i ++)
            {
                zuschlag += 0.07;
            }
            for (int i = 59; i <= totalPigs && i <= 92; i ++)
            {
                zuschlag += 0.01;
            }

            return zuschlag;
        }
        public static List<Schwein> GetPigs()
        {
            List<Schwein> schweineListe = new List<Schwein>();
            string[] zeilen = File.ReadAllLines(@"Schweine.txt");

            foreach (string zeile in zeilen)
            {
                string[] teile = zeile.Split(';');
                double weight = double.Parse(teile[0].Replace(',', '.'), CultureInfo.InvariantCulture);


                int MFA = int.Parse(teile[1]);
                bool ama = bool.Parse(teile[2]);
                double price = double.Parse(teile[3], CultureInfo.InvariantCulture);
                Schwein s = new Schwein(weight, MFA, ama, price);

                schweineListe.Add(s);
            }
            return schweineListe;
        }

    }
}
