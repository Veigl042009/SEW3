using System;
using System.Windows.Forms;
using Nakov.TurtleGraphics;

namespace _11_TurtleWindowsFormen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void printCross(int size, int level)
        {
            for (int i = 0; i < 4; i++)
            {
                if (level == 0)
                {
                    return;
                }
                Turtle.Forward(size);
                // Am Ende jedes Strichs wollen wir noch ein Kreuz zeichnen
                Turtle.Rotate(45);
                printCross(size / 2, level - 1);
                Turtle.Rotate(-45);
                Turtle.Backward(size);
                Turtle.Rotate(-90);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turtle.PenSize = 2;
            Turtle.PenDown();
            printCross(300, 5);  // Level legt die Tiefe der "Kreuze" (die Anzahl der geschachtelten Kreuze; die Rekursion) fest
        }
    }
}
