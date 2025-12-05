using TurtleGraphics;
using SixLabors.ImageSharp;

Turtle.PenDown();
Turtle.SetPenWidth(10);
void printCross(int size, int level)
{
    
    for (int i = 0; i < 4; i++)
    {
        if (level == 0)
            return;   // Abbruchbedingung
        Turtle.Forward(size);
        Turtle.TurnLeft(45);
        // hier ein weiteres Kreis
        printCross(size * 2 / 3, level - 1);    // GRöße auf 2/5 reduzieren
        Turtle.TurnRight(45);
        Turtle.Back(size);
        Turtle.TurnLeft(90);
    }
    
}   

printCross(50, 10);

Turtle.ShowTurtle();



