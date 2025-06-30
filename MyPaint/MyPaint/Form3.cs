using System;
using System.Drawing;
using System.Windows.Forms;


namespace MyPaint
{
    public partial class Form3 : Form
    {
        Form1 Fm;
        int X, Y, W, H;

        private void button2_Click(object sender, EventArgs e)
        {
            Fm.H = -1;
            Fm.W = -1;
            Fm.Y = -1;
            Fm.X = -1;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            X = (int)numericUpDownX.Value;
            Y = (int)numericUpDownY.Value;
            W = (int)numericUpDown2.Value;
            H = (int)numericUpDown1.Value;

            Fm.X = X;
            Fm.Y = Y;
            Fm.W = W;
            Fm.H = H;

            if (Fm.ActiveMenuItem != null)
            {
                Graphics g = Fm.CreateGraphics();

                switch (Fm.ActiveMenuItem)
                {
                    case "контурToolStripMenuItem":
                        Fm.DrawRectangl(g, X, Y, W, H);
                        break;
                    case "заливкаToolStripMenuItem":
                        Fm.DrawRectanglFill(g, X, Y, W, H);
                        break;
                    case "контурToolStripMenuItem1":
                        Fm.DrawEllipse(g, X, Y, W, H);
                        break;
                    case "заливкаToolStripMenuItem1":
                        Fm.DrawEllipseFull(g, X, Y, W, H);
                        break;
                    case "контурToolStripMenuItem2":
                        Fm.DrawPolygon(g);
                        break;
                    case "заливкаToolStripMenuItem2":
                        Fm.DrawPolygonFill(g);
                        break;
                    case "контурToolStripMenuItem3":
                        Fm.DrawPies(g, X, Y, W, H);
                        break;
                    case "заливкаToolStripMenuItem3":
                        Fm.DrawPiesFill(g, X, Y, W, H);
                        break;
                    case "дугаToolStripMenuItem":
                        Fm.DrawArc(g, X, Y, W, H);
                        break;
                    case "сплошнаяToolStripMenuItem":
                        Fm.DrawSolidLine(g, X, Y, W, H);
                        break;
                    case "прерывистаяToolStripMenuItem":
                        Fm.DrawDashLine(g, X, Y, W, H);
                        break;
                    case "пунктирнаяToolStripMenuItem":
                        Fm.DrawDashDotLine(g, X, Y, W, H);
                        break;
                }
                g.Dispose();
            }
            this.Close();
        }

        public Form3(Form1 fm)
        {
            InitializeComponent();
            Fm = fm;
        }
    }
}