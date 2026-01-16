// See https://aka.ms/new-console-template for more information
using _14_Inheritance;

Console.WriteLine("Hello, World!");


Person max = new Person("Max", "Mustermann");
max.Sleep();
max.Eat();

Farmer karmerFarmer = new Farmer("John", "Doe", "karmer");
karmerFarmer.Eat();
karmerFarmer.WorkOnFarm();
karmerFarmer.Sleep();

Emoplyee homer = new Emoplyee("Homer", "Simpson", "Nuclear plant");
homer.Eat();
homer.WorkAtCompany();
homer.Sleep();

List<Person> people = new List<Person>();
people.Add(max);
people.Add(karmerFarmer);
people.Add(homer);

foreach (Person person in people)
{
    person.Eat();
    person.Sleep();
}

Person donald = new Emoplyee("Donald", "Trump", "White House");

// Employee employee test = new Person("test", "test"); // geht nicht, da Person keine Employee ist
