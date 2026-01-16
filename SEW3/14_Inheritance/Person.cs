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
    }
}
