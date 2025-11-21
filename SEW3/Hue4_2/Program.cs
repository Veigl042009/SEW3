using Hue4_2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Shop shop = new Shop("SuperTech Store");

// Produkte anlegen
Product p1 = new Product("Laptop", 999.99, "Elektronik");
Product p2 = new Product("Schokolade", 1.49, "Lebensmittel");
Product p3 = new Product("Spielzeugauto", 14.99, "Spielzeug");

// Produkte hinzufügen
shop.AddProduct(p1);
shop.AddProduct(p2);
shop.AddProduct(p3);

// Ausgabe Inventar
shop.PrintInventory();

// Shop Zusammenfassung
shop.PrintSummary();

// Steuer & Währung anzeigen
Console.WriteLine($"\nAktueller Steuersatz: {PriceUtils.TaxRate}");
Console.WriteLine($"Währungssymbol: {PriceUtils.CurrencySymbol}");

// Globale Statistiken
Console.WriteLine($"\nErstellte Produkte insgesamt: {Product.ProductCount}");
Console.WriteLine($"Anzahl Shops insgesamt: {Shop.TotalShops}");

Console.WriteLine("\n===== Programm Ende =====");
