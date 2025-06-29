using System;
using System.Drawing;
using System.Windows.Forms;

namespace _19._06
{
    public partial class Form1 : Form
    {
        private Form2 form2;

        public Form1()
        {
            InitializeComponent();

            form2 = new Form2();

            btnCheck.Click += BtnCheck_Click;
            btnOpenLog.Click += BtnOpenLog_Click;
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string seriesText = txtSeries.Text.Trim();
            string numberText = txtNumber.Text.Trim();

            bool validSeries = int.TryParse(seriesText, out int series) && series >= 6901 && series <= 6904;
            bool validNumber = int.TryParse(numberText, out int number) && number >= 100000 && number <= 800000;

            string result = $"{seriesText} {numberText} — " + (validSeries && validNumber ? "Верно" : "Неверно");
            Color color = (validSeries && validNumber) ? Color.Black : Color.Red;

            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2();
            }
            form2.AddLog(result, color);
        }

        private void BtnOpenLog_Click(object sender, EventArgs e)
        {
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2();
            }
            form2.Show();
            form2.BringToFront();
        }
    }
}
