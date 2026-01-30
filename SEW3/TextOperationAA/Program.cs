using System;
using TextOperationAA;

Console.Write("Geben Sie einen Text ein: ");

string? input = Console.ReadLine();


if (input is null)
{
    Console.WriteLine("Kein Text eingegeben.");
    return; 
}

Console.WriteLine("\n--- ApplyOperation Beispiele ---");

// 1) Text in Großbuchstaben umwandeln
string upper = TextUtilities.ApplyOperation(input, TextOperation.ToUpper);
Console.WriteLine("ToUpper: " + upper);

// 2) Text in Kleinbuchstaben umwandeln
string lower = TextUtilities.ApplyOperation(input, TextOperation.ToLower);
Console.WriteLine("ToLower: " + lower);

// 3) Text rückwärts ausgeben
string reversed = TextUtilities.ApplyOperation(input, TextOperation.Reverse);
Console.WriteLine("Reverse: " + reversed);

// 4) Vokale durch * ersetzen
string replaced = TextUtilities.ApplyOperation(input, TextOperation.ReplaceVowels);
Console.WriteLine("ReplaceVowels: " + replaced);

// 5) Wörter zählen
string wordCount = TextUtilities.ApplyOperation(input, TextOperation.CountWords);
Console.WriteLine("CountWords: " + wordCount);

Console.WriteLine("\n--- NormalizeText (ref) ---");

// Beispieltext mit vielen Leerzeichen
string text1 = "   Das     ist   ein   Test   ";
Console.WriteLine("Vorher: '" + text1 + "'");

// ref = Text wird direkt verändert
TextUtilities.NormalizeText(ref text1);

Console.WriteLine("Nachher: '" + text1 + "'");

Console.WriteLine("\n--- NormalizeTextCopy ---");

// Original bleibt unverändert
string text2 = "   Hallo      Welt   ";
Console.WriteLine("Original: '" + text2 + "'");

// Neue, bereinigte Kopie
string normalizedCopy = TextUtilities.NormalizeTextCopy(text2);

Console.WriteLine("Kopie:    '" + normalizedCopy + "'");
Console.WriteLine("Original bleibt: '" + text2 + "'");
