using Hue2_2_Approxi;

Console.Write("Bitte ein Wort eingeben: ");
string input = Console.ReadLine();
List<char> word = input.ToList();

ApproximateMatchingString matcher = new ApproximateMatchingString(word, @"..\..\..\german_unsorted.txt");

List<string> result = matcher.Suggestions(word);

foreach (string s in result)
{
    Console.WriteLine(s);
}
