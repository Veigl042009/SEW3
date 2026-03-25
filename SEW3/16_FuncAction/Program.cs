// See https://aka.ms/new-console-template for more information
using _16_FuncAction;

Console.WriteLine("Hello, World!");

DelegateDemo.CalculateSomething();

Logger myLogger = new Logger();

myLogger.LogReceived += ConsoleLogger;

void ConsoleLogger(string message, int priority)
{
    Console.WriteLine(message);
}
myLogger.AddLog("Programm gestartet", 1);
myLogger.AddLog("Programm beendet", 2);