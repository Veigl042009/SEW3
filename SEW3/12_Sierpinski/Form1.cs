using Nakov.TurtleGraphics;

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
            SPoint a = new SPoint(-200, -200);
            SPoint b = new SPoint(200, -200);
            SPoint c = new SPoint(0, 200);
            STriangle t = new STriangle(a, b, c);
            Sierpinski(5, t);
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
            STriangle innerTriangle = new STriangle(t.A, t.MidBC, t.MidCA); // linke kleine Dreieck
            Sierpinski(level - 1, innerTriangle);
            innerTriangle = new STriangle(t.B, t.MidAB, t.MidBC); // rechte kleine Dreieck

        }
    }
}
    