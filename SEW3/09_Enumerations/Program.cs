// See https://aka.ms/new-console-template for more information

Status homework = Status.Abgeschlossen;
Console.WriteLine(homework);
if(homework == Status.Abgeschlossen)
{
    Console.WriteLine("Super, du bist fleissig!");
}

public enum Status
{
    Erstellt,
    Geplant,
    Begonnen,
    Pausiert,
    Abgeschlossen,
}


