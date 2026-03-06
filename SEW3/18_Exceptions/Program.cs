// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
bool isDevelopment = true;

try
{

    string text = File.ReadAllText(@"C:\DEV\myfile.txt"); //wenn die Datei nicht existiert, wird eine Exception ausgelöst)
    Console.WriteLine(text);
}
catch (FileNotFoundException ex) // spezifische Exception abfangen
{
    Console.WriteLine($"Die Datei wurde nicht gefunden. Bitte überprüfen Sie den Pfad: {ex.FileName}");
    Console.WriteLine($"Fehlermeldung: {ex.Message}");
    Console.WriteLine("-----------------------");
    if (isDevelopment)
    {
        Console.WriteLine(ex.StackTrace);
    }
}catch (UnauthorizedAccessException ex) // spezifische Exception abfangen
{
    Console.WriteLine($"Zugriff auf die Datei verweigert.{ex.Message}");
    // hier treffen dann alle übrigen Exeptions ein
    Console.WriteLine("Hoppla da ist etwas schief gelaufen. Bitte wenden Sie sich an den Support.");
}









//catch // alle Exceptions abfangen
//{
//    Console.WriteLine("EIn Fehler ist aufgetreten. Keine Ahnung welcher.");
//}
