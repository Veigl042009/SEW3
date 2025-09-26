string text = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Quisque faucibus ex sapien vitae pellentesque sem placerat. In id cursus mi pretium tellus duis convallis. Tempus leo eu aenean sed diam urna tempor. Pulvinar vivamus fringilla lacus nec metus bibendum egestas. Iaculis massa nisl malesuada lacinia integer nunc posuere. Ut hendrerit semper vel class aptent taciti sociosqu. Ad litora torquent per conubia nostra inceptos himenaeos.\r\n\r\nLorem ipsum dolor sit amet consectetur adipiscing elit. Quisque faucibus ex sapien vitae pellentesque sem placerat. In id cursus mi pretium tellus duis convallis. Tempus leo eu aenean sed diam urna tempor. Pulvinar vivamus fringilla lacus nec metus bibendum egestas. Iaculis massa nisl malesuada lacinia integer nunc posuere. Ut hendrerit semper vel class aptent taciti sociosqu. Ad litora torquent per conubia nostra inceptos himenaeos.";

File.WriteAllText("output.txt", text);

string[] names = ["Kamleitner", "Obernberger", "Kashofer", "Auer"];
File.WriteAllLines("outputarry.txt", names);

File.AppendAllText("output_append.txt", "hello"); // Beim erstenmal wird es erstellt und dann immer im dokument angehängt

string[] plants = File.ReadAllLines("Namen.txt");

//foreach(string plant in plants)
///{
//    Console.WriteLine(plant);
//}

Console.WriteLine(plants[5]);

string[] plantDetails = plants[5].Split(',');

Console.WriteLine(plantDetails[4]);