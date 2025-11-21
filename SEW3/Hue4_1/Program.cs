using System;
using Hue4_1;

Console.WriteLine("Überpfrüfungs Beispiele\n");

// Winkel
Console.WriteLine("RadToDegree(1) = " + Converter.RadToDegree(1));
Console.WriteLine("DegreeToRad(180) = " + Converter.DegreeToRad(180));

// Entfernung
Console.WriteLine("\nToMiles(10 km) = " + Converter.ToMiles(10));
Console.WriteLine("ToKm(10 Meilen) = " + Converter.ToKm(10));

// Temperatur Celsius -> Fahrenheit
Console.WriteLine("\nToFahrenheit(0°C) = " + Converter.ToFahrenheit(0));

// Temperatur Fahrenheit -> Celsius
Console.WriteLine("ToDegree(32°F) = " + Converter.ToDegree(32));

// Temperatur Kelvin -> Fahrenheit
Console.WriteLine("\nToFahrenheitFromKelvin(300 K) = " + Converter.ToFahrenheitFromKelvin(300));

// Temperatur Kelvin -> Celsius
Console.WriteLine("ToDegreeFromKelvin(300 K) = " + Converter.ToDegreeFromKelvin(300));

// Temperatur Celsius -> Kelvin
Console.WriteLine("\nToKelvin(25°C) = " + Converter.ToKelvin(25));

// Temperatur Fahrenheit -> Kelvin
Console.WriteLine("ToKelvinFromFahrenheit(32°F) = " + Converter.ToKelvinFromFahrenheit(32));

Console.ReadKey();
    

