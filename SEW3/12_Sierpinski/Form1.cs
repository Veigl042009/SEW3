using Nakov.TurtleGraphics;
using System;

namespace _12_Sierpinski
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turtle.PenSize = 2;
            SPoint a = new SPoint(-500, -500);
            SPoint b = new SPoint(500, -500);
            SPoint c = new SPoint(0, 500);
            STriangle t = new STriangle(a, b, c);
            Sierpinski(6, t);
        }

        private void DrawTriangele(STriangle t)
        {
            Turtle.PenUp();
            Turtle.MoveTo(t.A.X, t.A.Y);
            Turtle.PenDown();
            Turtle.MoveTo(t.B.X, t.B.Y);
            Turtle.MoveTo(t.C.X, t.C.Y);
            Turtle.MoveTo(t.A.X, t.A.Y);


        }

        private void Sierpinski(int level, STriangle t)



        {
            if (level == 0)
            {
                return;
            }

            DrawTriangele(t);
            STriangle innerTriangle = new STriangle(t.A, t.MidAB, t.MidCA); // linke kleine Dreieck
            Turtle.PenColor = Color.Red;
            Sierpinski(level - 1, innerTriangle);
            innerTriangle = new STriangle(t.B, t.MidAB, t.MidBC); // rechte kleine Dreieck
            Turtle.PenColor = Color.Yellow;
            Sierpinski(level - 1, innerTriangle);
            innerTriangle = new STriangle(t.C, t.MidBC, t.MidCA); // obere kleine Dreieck
            Turtle.PenColor = Color.Orange;
            Sierpinski(level - 1, innerTriangle);

        }
    }
}
    