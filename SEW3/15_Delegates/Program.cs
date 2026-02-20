using _15_Delegates;

DelegateDemo.CalculateSomething();

Logger myLogger = new Logger();

myLogger.LogReceived += ConsoleLogger;
myLogger.LogReceived += FileLogger; // zusätzlich zum Konsolenlogger wird auch der FileLogger angemeldet
myLogger.LogReceived += ConsoleLoggerEH;

void ConsoleLoggerEH(object? sender, EventArgs e)
{
    if (e is LogEventArgs)
    {
        LogEventArgs lea = (LogEventArgs)e;
        Console.WriteLine(lea.Message, lea.Priority);
    }
    
}

void FileLogger(string message, int priority)
{
    if (priority < 3)
    {
        File.AppendAllText("log.txt", message + Environment.NewLine);
    }
}
void ConsoleLogger(string message, int priority)
{
    Console.WriteLine(message);
}

myLogger.AddLog("Programm gestartet", 1);
myLogger.AddLog("Programm läuft", 5);


// hier passiert nichts

myLogger.AddLog("Ein Ferhler ist aufgetreten", 1);
myLogger.AddLog("Details zum Fehler:...", 3);

myLogger.AddLog("Aufgabe erfolgreich erledigt.", 2);

myLogger.LogReceived -= ConsoleLogger; // Abmeldung des ConsoleLoggers, damit nur noch der FileLogger die Logs empfängt
myLogger.AddLog("Programm wird beendet, warte auf neue", 2); // nur noch im FileLogger, da ConsoleLogger abgemeldet