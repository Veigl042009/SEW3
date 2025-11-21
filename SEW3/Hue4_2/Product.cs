using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue4_2
{
    internal class Product
    {
        public static int ProductCount { get; private set; } = 0;

        public string Name { get; set; }
        public double NetPrice { get; set; }
        public string Category { get; set; }

        public Product(string name, double netPrice, string category)
        {
            // Validierung mit sinnvollen Defaults
            Name = string.IsNullOrWhiteSpace(name) ? "Unbekanntes Produkt" : name;
            NetPrice = netPrice >= 0 ? netPrice : 0;
            Category = string.IsNullOrWhiteSpace(category) ? "Allgemein" : category;

            ProductCount++;
        }

        public double GetGrossPrice()
        {
            return PriceUtils.CalculateGross(NetPrice);
        }

        public void PrintInfo()
        {
            Console.WriteLine("----- Produkt -----");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Kategorie: {Category}");
            Console.WriteLine($"Netto:   {PriceUtils.FormatPrice(NetPrice)}");
            Console.WriteLine($"Brutto:  {PriceUtils.FormatPrice(GetGrossPrice())}");
        }
    }

}

