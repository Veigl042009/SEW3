using _08_CallByReference;

int a = 5;
int result = Calculator.CalculateDouble(a);
Console.WriteLine($"Ergebnis: {result}");
Console.WriteLine(a);

int result2;
Calculator.CalculateDouble(a, out result2);      // Argument out kann mit einer uninitialisierten Variable aufgerufen werden
Console.WriteLine($"Ergebnis: {result2}");

Calculator.CalculateDouble(ref a);
Console.WriteLine($"Ergebnis: {a}");

// Konvertierung von Datentypen
string? s = Console.ReadLine();
int z;
if(int.TryParse(s, out z))
{
 Console.WriteLine($"Konvertierung erfolgreich: {z}");
}
else
{
    Console.WriteLine("Konvertierung fehlgeschlagen");
}
