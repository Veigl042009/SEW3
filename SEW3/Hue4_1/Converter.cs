using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue4_1
{
    internal class Converter
    
    {
        // Winkel
        public static double RadToDegree(double rad)
        {
            return rad * (180.0 / Math.PI);
        }

        public static double DegreeToRad(double degree)
        {
            return degree * (Math.PI / 180.0);
        }

        // Entfernung
        public static double ToMiles(double km)
        {
            return km * 0.621371;
        }

        public static double ToKm(double miles)
        {
            return miles / 0.621371;
        }

        // Temperatur: Celsius -> Fahrenheit
        public static double ToFahrenheit(double degree)
        {
            return degree * 9.0 / 5.0 + 32.0;
        }

        // Temperatur: Fahrenheit -> Celsius
        public static double ToDegree(double fahrenheit)
        {
            return (fahrenheit - 32.0) * 5.0 / 9.0;
        }

        // Temperatur: Kelvin -> Fahrenheit
        public static double ToFahrenheitFromKelvin(double kelvin)
        {
            return (kelvin - 273.15) * 9.0 / 5.0 + 32.0;
        }

        // Temperatur: Kelvin -> Celsius
        public static double ToDegreeFromKelvin(double kelvin)
        {
            return kelvin - 273.15;
        }

        // Temperatur: Celsius -> Kelvin
        public static double ToKelvin(double degree)
        {
            return degree + 273.15;
        }

        // Temperatur: Fahrenheit -> Kelvin
        public static double ToKelvinFromFahrenheit(double fahrenheit)
        {
            return (fahrenheit - 32.0) * 5.0 / 9.0 + 273.15;
        }
    }

    

}

