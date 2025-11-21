using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue4_2
{
    internal class Shop
    {
        public static int TotalShops { get; private set; } = 0;

        public string Name { get; set; }
        public List<Product> Products { get; private set; }

        // Konstruktorname muss mit dem Klassennamen übereinstimmen!
        public Shop(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unbenannter Shop" : name;
            Products = new List<Product>();

            TotalShops++;
        }

        public void AddProduct(Product p)
        {
            if (p != null)
                Products.Add(p);
        }

        public double GetTotalGrossValue()
        {
            double sum = 0;
            foreach (var p in Products)
            {
                sum += p.GetGrossPrice();
            }
            return sum;
        }

        public void PrintInventory()
        {
            Console.WriteLine("\n=== Inventar ===");
            foreach (var p in Products)
            {
                p.PrintInfo();
            }
        }

        public void PrintSummary()
        {
            Console.WriteLine("\n=== Shop Zusammenfassung ===");
            Console.WriteLine($"Shopname: {Name}");
            Console.WriteLine($"Produkte: {Products.Count}");
            Console.WriteLine($"Gesamtwert (Brutto): {PriceUtils.FormatPrice(GetTotalGrossValue())}");
        }
    }
}