using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Inheritance
{
    internal class Farmer : Person
    {
        private string farmName;

        public Farmer(string firstName, string lastName, string farmName) : base(firstName, lastName)  // Aufruf des Konstruktors der Basisklasse Person
        {
            // this.firstName = firstName; // this.firstName geerbt aus der Basisklasse Person
            // this.lastName = lastName;   // this.lastName geerbt aus der Basisklasse Person
            this.farmName = farmName;   // attribut der Klasse
        }


        public void WorkOnFarm()
        {
            Console.WriteLine($"{firstName} {lastName} is working on the farm '{farmName}'.");
        }
        public override void GetInfo()           // override kennzeichnet, dass die Methode der Basisklasse überschrieben wird
        {
            Console.WriteLine($"{ firstName} { lastName} is a Farmer");
        }
    }
}
