// See https://aka.ms/new-console-template for more information
using _14_Inheritance;

Console.WriteLine("Hello, World!");


Person max = new Person("Max", "Mustermann");
max.Sleep();
max.Eat();

Console.WriteLine(max.ToString()); 
Console.WriteLine(max);  // Das ToSTring braucht man nicht das ist im Console.WriteLine schon drin


Farmer karmerFarmer = new Farmer("John", "Doe", "karmer");
karmerFarmer.Eat();
karmerFarmer.WorkOnFarm();
karmerFarmer.Sleep();
karmerFarmer.GetInfo();

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

Person clarkson = new Farmer("Jeremy", "Clarkson", "Clarkson Farm");    // statischer Datentyp:: Person
                                                                        // dynamischer Datentyp:: Farmer
clarkson.GetInfo();                                                     // Aufruf der überschriebenen Methode in der Klasse Farmer

people.Add(donald);
people.Add(clarkson);

foreach (Person p in people)
{
    p.GetInfo();
}

Rectangle a1 = new Rectangle(4, 5);
Rectangle a2 = new Rectangle(8, 9);
Rectangle a3 = new Rectangle(4, 5);
Rectangle a4 = new Rectangle(5, 4);

Console.WriteLine($"a1 == a2: {a1.Equals(a2)}");
Console.WriteLine($"a1 == a3: {a1.Equals(a3)}");
Console.WriteLine($"a1 == a4: {a1.Equals(a4)}");



