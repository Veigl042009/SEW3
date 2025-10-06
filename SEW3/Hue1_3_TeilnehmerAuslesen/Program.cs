string[] zeilen = File.ReadAllLines(@"C:\Users\Andreas\source\repos\SEW3\SEW3\SEW3\Hue1_2_TeilnehmerListe\bin\Debug\net9.0\teilnehmer.csv");

int gesamt = 0;
int juenger18 = 0;
int aelter65 = 0;
int zwischen18_65 = 0;

for (int i = 0; i < zeilen.Length; i++)
{
    string[] teile = zeilen[i].Split(';');

    string vorname = teile[0];
    string nachname = teile[1];
    DateTime geburtsdatum = DateTime.Parse(teile[2]);

    DateTime heute = DateTime.Today;
    int alter = heute.Year - geburtsdatum.Year;
    if (geburtsdatum.Date > heute.AddYears(-alter)) alter--;

    gesamt++;
    if (alter < 18) juenger18++;
    else if (alter > 65) aelter65++;
    else zwischen18_65++;

    Console.WriteLine($"{vorname} {nachname}, geboren am {geburtsdatum:dd.MM.yyyy}, Alter: {alter}");
}

Console.WriteLine($"Personen gesamt: {gesamt}");
Console.WriteLine($"Personen jünger als 18: {juenger18}");
Console.WriteLine($"Personen älter als 65: {aelter65}");
Console.WriteLine($"Personen zwischen 18 und 65: {zwischen18_65}");