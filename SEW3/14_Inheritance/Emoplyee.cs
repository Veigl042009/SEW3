using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Inheritance
{
    internal class Emoplyee : Person
    {
        private string companyName;
        public Emoplyee(string firstName, string lastName, string companyName) : base(firstName, lastName)  // Aufruf des Konstruktors der Basisklasse Person
        {
            // this.firstName = firstName; // this.firstName geerbt aus der Basisklasse Person
            // this.lastName = lastName;   // this.lastName geerbt aus der Basisklasse Person
            this.companyName = companyName;   // attribut der Klasse
        }
        public void WorkAtCompany()
        {
            Console.WriteLine($"{firstName} {lastName} is working at the company '{companyName}'.");
        }
        public new void GetInfo()           // override kennzeichnet, dass die Methode der Basisklasse überschrieben wird
        {
            Console.WriteLine($"{ firstName} { lastName} is an Employee");
        }
    }
}
