
using TokenAA;

Console.Write("Bitte den zu analysierenden Text eingeben: ");
string? input = Console.ReadLine();

var tokens = Tokenizer.Tokenize(input);

Console.WriteLine("\nErgebnis:");
foreach (var token in tokens)
{
    Console.WriteLine(token);
}