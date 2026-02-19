// See https://aka.ms/new-console-template for more information
using Hue8_Maut;

// Fahrzeuge erstellen
Vehicle car = new Car("W-123AB", 1500);
Vehicle truck = new Truck("L-999XY", 12000);
Vehicle moto = new Motorcycle("AM-45ZZ", 200);

// Mautstation erstellen
Tollstation station = new Tollstation("A1 West");

// Fahrzeuge durchfahren lassen
station.VehiclePasses(car);
station.VehiclePasses(truck);
station.VehiclePasses(moto);

// Gesamteinnahmen ausgeben
Console.WriteLine($"\nGesamteinnahmen: {station.TotalToll:F2} Euro");