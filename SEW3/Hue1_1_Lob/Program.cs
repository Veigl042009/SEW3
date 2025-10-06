List<string> adjektive = new(File.ReadAllLines("adjektive.txt"));
List<string> nomenM = new(File.ReadAllLines("nomen_m.txt"));
List<string> nomenW = new(File.ReadAllLines("nomen_w.txt"));

Console.Write("Wie viele Lobeszeilen möchtest du? ");
int anzahl = int.Parse(Console.ReadLine());

Console.Write("Geschlecht (m = männlich, w = weiblich): ");
char geschlecht = Console.ReadLine()[0];

Random rnd = new();

for (int i = 0; i < anzahl; i++)
{
    string adj = adjektive[rnd.Next(adjektive.Count)];
    string nomen;

    if (geschlecht == 'm')
        nomen = nomenM[rnd.Next(nomenM.Count)];
    else
        nomen = nomenW[rnd.Next(nomenW.Count)];

    string artikel;

    if (nomenW.Contains(nomen))
        artikel = "die";
    else
        artikel = "der";

    Console.WriteLine($"Du bist {artikel} {adj} {nomen}");
}
