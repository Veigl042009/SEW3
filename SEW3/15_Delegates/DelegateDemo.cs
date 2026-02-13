using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Delegates
{
    internal class DelegateDemo
    {
        delegate int CalculationHandler(int x, int y);
        // private static CalculationHandler operation = new CalculationHandler(Addition);
        private static CalculationHandler operation = Addition; // Alternative Schreibweise, da die Methode bereits die Signatur des Delegates erfüllt
        // operation = Name der Datenkomponente
        // Addition ist die Methode, die dem Delegate zugewiesen wird
        // Beachte: Methode hier ohne Klammer, weil die Methode zugewiesen werden soll und nicht aufgerufen
        private static event CalculationHandler operationEvent; // Zuweisung mehrerer Methoden möglich

        private static int Addition(int addend1, int addend2)
        {
            return addend1 + addend2;
        }
        private static int Subtraction(int minuend, int subtrahend)
        {
            return minuend - subtrahend;
        }

        public static void CalculateSomething()
        {
            int result = operation(4, 5);
            Console.WriteLine(result); // Ausgabe: 9

            operation = new CalculationHandler(Subtraction);
            result = operation(4, 5);
            Console.WriteLine(result);// Ausgabe: -1

        }
    }
}
