using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Static
{
    internal class Example
    {
        private static int count = 0;      // Nur einmal pro Klasse vorhanden
        public static double PI
        {
            get
            {
                return 3.14159;
            }
        }
        // in einer KLasse wo nur statische MEthoden vorkommen --> kein Konstruktor

        public static void DoSomehting()
        {
            // in statischen Methoden kann man auf statische Datenkomponenten zugreifen
            count++;
            Console.WriteLine($"Ich bin eine Statische Methode und wurde {count} MAl aufgerufen");
        }
        public void DoSomethingElse()
        {
            // in nicht statischen Elementen kann ich auf statische Elemente zugreifen

            Console.WriteLine($"Ich bin eine NICHT statische Methode und hänge am Objekt., KAnn aber auf staitische Elemente zugreifen, z.B: {Example.PI}");
        }
    }
}
