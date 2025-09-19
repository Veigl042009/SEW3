
// FJHerbariumLibrary.Herbarium = new FJHerbariumLibrary.Herbarium(); // full qualified
using FJHerbariumLibrary;

Herbarium myHerbarium = new Herbarium();
myHerbarium.Generate("Herbarium.Template2.pptx", @"C:\Users\andreas.veigl\Desktop", "Namen.txt", @"C:\Users\andreas.veigl\source\repos\Herbarium_Veigl");  // @ bedeuted, keine Escape Sequenzen für \