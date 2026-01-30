using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Inheritance
{
    internal class Person
    {
        protected string firstName;
        protected string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void Sleep()
        {
            Console.WriteLine($"{firstName} {lastName} is sleeping.");
        }
        
        public void Eat()
        {
            Console.WriteLine($"{firstName} {lastName} is eating.");
        }

        public virtual void GetInfo()           // virtual kennzeichnet, dass Methoden in abgeleiteten Klassen überschrieben werden können
        {
            Console.WriteLine($"{ firstName} { lastName} is a Person");
        }

        public override string ToString()
        {
            return $"Person: {firstName} {lastName}";
        }


    }
}
