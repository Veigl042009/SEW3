while (true)
{
    Console.Write("Vorname (oder e zum Beenden): ");
    string vorname = Console.ReadLine();

    if (vorname.ToLower() == "e")
        break;

    Console.Write("Nachname: ");
    string nachname = Console.ReadLine();

    Console.Write("Geburtsdatum: ");
    string geburtsdatum = Console.ReadLine();

    string daten = $"{vorname};{nachname};{geburtsdatum}\n";

    File.AppendAllText("teilnehmer.csv", daten);
}