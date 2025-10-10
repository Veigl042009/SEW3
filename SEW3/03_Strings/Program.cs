// See https://aka.ms/new-console-template for more information
using _03_Strings;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");

// Formatstings
// Benutzer soll Zahl eingeben
// Darstellungen:
//                  - Binär
//                  - Hexadezimal
//                  - 10 stellig
//                  - als Währung
//                  - mit Tausenderseparator


// 2. Formatstings
// Benutzer soll Gleitkommazahl eingeben.
//                                          - Runden auf 1 Nachkommer
//                                          - Prozentzahl
//                                          - Währung mit 2 Nachkomma

// 3. Benutzer gibt einen Text und einen Suchtext ein. Ergebnis soll sein, wie oft der Suchtext im Text vorkommt.
// 4. Cäsar Verschlüsselung (Siehe Code Skript). Erstellt zusätzlich eine Methode Entschlüsseln. Zuerst überlegen, dann arbeiten!!!


Console.WriteLine("Bitte geben SIe eine Zahl ein: ");
int num;
num = int.Parse(Console.ReadLine());
Console.WriteLine($"Binär:{num:b}");
Console.WriteLine($"Hexadezimal:{num:x}");
Console.WriteLine($"10 stellig:{num:d10}");
Console.WriteLine($"Währung:{num:c}");
Console.WriteLine($"Tausenderseparator:{num:n}");

Console.WriteLine("Bitte geben Sie eine Kommazahl ein: ");
double num2;
num2 = double.Parse(Console.ReadLine());
Console.WriteLine($"Eine Nachkommastelle {num2:f1}");
Console.WriteLine($"Prozentzahlrunden {num2:p}");
Console.WriteLine($"Zwei Nachkommastellen {num2:f2}");

string txt;
string search;
Console.WriteLine("Bitte gib einen Ausgangstext ein.");
txt = Console.ReadLine();
txt.Trim();
Console.WriteLine("Bitte gib einen Suchtext ein.");
search = Console.ReadLine();
search.Trim();
int count = 0;
int index = 0;

// Schleife, um alle Vorkommen zu finden
while ((index = txt.IndexOf(search, index)) != -1)
{
    count++;
    index += search.Length; // Weiter suchen nach dem aktuellen Vorkommen
}

Console.WriteLine($"'{search}' kommt {count} mal im Text vor.");

Caesar caesar = new Caesar();

Console.Write("Gib den Text ein: ");
string text = Console.ReadLine();

Console.Write("Gib den Schlüssel ein: ");
int schluessel = int.Parse(Console.ReadLine());

// Verschlüsseln
string verschluesselt = caesar.Verschluesseln(text, schluessel);
Console.WriteLine("Verschlüsselt: " + verschluesselt);

// Entschlüsseln
string entschluesselt = caesar.Entschluesseln(verschluesselt, schluessel);
Console.WriteLine("Entschlüsselt: " + entschluesselt);

