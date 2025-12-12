
// alle möglichen Kominationen mit einer bestimmten Länge

string charset = "abcdefghijklmnopqrstuvwxyz123456789#+!.;-<";   // Zeichen, die verwendet werden sollen
Console.Write("Geben Sie die gewünschte Passwortlänge ein: ");
string input = Console.ReadLine();
int length;
if (!int.TryParse(input, out length))
{
    Console.WriteLine("ungültige Eingabe.");
    return;

}
using (StreamWriter writer = new StreamWriter("C:\\Users\\andreas.veigl\\Desktop\\output.txt"))
{
    GenerateRecursive(charset, "", length, writer);
}
Console.WriteLine("Fertig! Alle Kombinationen wurden in 'output.txt' gespeichert.");

void GenerateRecursive(string charset, string current, int remaining, StreamWriter writer)
{
    if (remaining == 0)
    {
        writer.WriteLine(current);
    }
    else
    {
        // 1 Buchstabe anhängen und an die nächste Ebene weitergeben (rekursiver Aufruf)
        foreach (char c in charset)
        {
            GenerateRecursive(charset, current + c, remaining - 1, writer);
        }
    }

}