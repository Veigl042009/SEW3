using System.Windows.Forms;
using Nakov.TurtleGraphics;
using System;

namespace RekursionAA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var turtle = new Turtle();
            turtle.PenDown();
        }
        private void Form1_Load(object sender, EventArgs e) { MessageBox.Show("Form wurde geladen!"); }
        private void button1_Click(object sender, EventArgs e)
        {
            

            // Startquadrat (unten)
            Draw(400, 500, 200);
        }

        private void Draw(float x, float y, float size)
        {
            // Abbruchkriterium
            if (size < 2)
                return;

            DrawSquare(x, y, size);

            float newSize = size / 3;

            // Anzahl kleiner Quadrate oben
            int count = 7;
            float startX = x - (count / 2f) * newSize;

            for (int i = 0; i < count; i++)
            {
                float childX = startX + i * newSize;
                float childY = y - size / 2 - newSize / 2;

                Draw(childX, childY, newSize);
            }
        }

        private void DrawSquare(float x, float y, float size)
        {
            Turtle.PenUp();
            Turtle.X = x - size / 2;
            Turtle.Y = y - size / 2;
            Turtle.Angle = 0;
            Turtle.PenDown();

            for (int i = 0; i < 4; i++)
            {
                Turtle.Forward(size);
                Turtle.Rotate(-90);
            }
        }
    }
}