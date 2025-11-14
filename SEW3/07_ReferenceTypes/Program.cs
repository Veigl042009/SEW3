// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Dynamic;

int i = 5; //value Type
int? j = 6; //Reference Type

Random random = new Random();
if(random.Next() % 2 == 0)
{
    j = null;
}

int[] types = { 1, 3, 5, 6 }; //Reference Type

Console.WriteLine($"i: {i}");

if (j.HasValue)
{
   Console.WriteLine($"j: {j.Value}");
}

Console.WriteLine($"j: {j.GetValueOrDefault()}");         // gib mir den Wert, außer er ist null, dann gib 0 zurück
Console.WriteLine($"j: {j.GetValueOrDefault(-1)}");        // gib mir den Wert, außer er ist null, dann gib -1 zurück
Console.WriteLine($"j: {j ?? -1}");                        // gib mir den Wert, außer er ist null, dann gib -1 zurück
Console.WriteLine($"j: {j ?? 0}");                         // gib mir den Wert, außer er ist null, dann gib 0 zurück

j!.ToString(); // Der Wert ist niemals null, also rufe die Methode auf (ToSTring kann auch mit null umgehen)

List<int> list = null;
list = new List<int>();
int[] listAsArry = list!.ToArray();