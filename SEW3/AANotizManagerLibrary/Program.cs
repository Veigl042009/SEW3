using AANotizManagerLibrary;

NotizManager notizManager = new NotizManager();

// Benutzer nach der Notiz fragen
Console.WriteLine("Bitte geben Sie Ihre Notiz ein (drücken Sie Enter zum Beenden):");
string eingabe = Console.ReadLine();
notizManager.NotizText = eingabe;

// Wörter zählen
int anzahlWoerter = notizManager.ZaehleWoerter();

// Ergebnis ausgeben
Console.WriteLine($"Ihre Notiz enthält {anzahlWoerter} Wörter.");

string dateipfad = "notiz.txt";

// Notiz speichern und direkt prüfen, ob es erfolgreich war
if (notizManager.SpeichereInDatei(dateipfad))
{
    Console.WriteLine($"\nNotiz wurde erfolgreich in '{dateipfad}' gespeichert.");
}
else
{
    Console.WriteLine($"\nFehler beim Speichern der Notiz in '{dateipfad}'.");
}

// Notiz aus Datei laden
string geladeneNotiz = notizManager.LadeAusDatei(dateipfad);
Console.WriteLine("\nNotiz aus der Datei:");
Console.WriteLine(geladeneNotiz);

// Wort ersetzen
string alterText = "Test";
string neuerText = "Beispiel";

string neuerNotiz = notizManager.ErsetzeText(alterText, neuerText);
Console.WriteLine($"\nNotiz nach dem Ersetzen von '{alterText}' durch '{neuerText}':");
Console.WriteLine(neuerNotiz);
