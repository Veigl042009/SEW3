using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue4_2
{
    internal class PriceUtils
    {
            private static double taxRate = 0.2;
            public static double TaxRate
            {
                get => taxRate;
                set
                {
                    if (value >= 0.0 && value <= 0.5)
                        taxRate = value;
                    else
                        taxRate = 0.2; // Standardwert bei ungültigem Input
                }
            }

            private static string currencySymbol = "€";
            public static string CurrencySymbol
            {
                get => currencySymbol;
                set
                {
                    currencySymbol = string.IsNullOrWhiteSpace(value) ? "€" : value;
                }
            }

            public static double CalculateGross(double netPrice)
            {
                return netPrice * (1 + TaxRate);
            }

            public static double CalculateNet(double grossPrice)
            {
                return grossPrice / (1 + TaxRate);
            }

            public static string FormatPrice(double amount)
            {
                return $"{CurrencySymbol} {amount:0.00}";
            }

    }
}
