using Hue2_Approxi;

class Program
{
    static void Main()
    {
        Console.Write("Bitte gib ein Wort ein: ");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Kein Wort eingegeben.");
            return;
        }

        ApproximateMatchingString ams = new ApproximateMatchingString(input);
        List<string> suggestions = ams.Suggestions;

        Console.WriteLine("\nVorschläge für '" + input + "':");
        if (suggestions.Count == 0)
            Console.WriteLine("  (Keine Vorschläge gefunden)");
        else
            foreach (string s in suggestions)
                Console.WriteLine(" - " + s);

        Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden...");
        Console.ReadKey();
    }
}

