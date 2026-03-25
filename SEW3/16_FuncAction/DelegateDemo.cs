using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_FuncAction
{
    internal class DelegateDemo // gleiche Funktionalität wie 15_Delegates.DelegateDemo, aber mit Func und Action Delegates
    {
       // delegate int CalculationHandler(int x, int y);
       // private static CalculationHandler operation = Addition;

        private static Func<int, int, int> operation = Addition; // ersten beiden int --> Parameter drittes int --> Result Alternative Schreibweise, da die Methode bereits die Signatur des Delegates erfüllt
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

            operation = Subtraction;
            result = operation(4, 5);
            Console.WriteLine(result);// Ausgabe: -1

        }
    }
}
