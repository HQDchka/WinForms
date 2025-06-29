using System;
using System.Drawing;
using System.Windows.Forms;

namespace _19._06
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            listBoxLog.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxLog.DrawItem += ListBoxLog_DrawItem;

            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide(); 
        }


        public void AddLog(string message, Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddLog(message, color)));
                return;
            }

            listBoxLog.Items.Add(new LogItem(message, color));
        }

        private void ListBoxLog_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0 && e.Index < listBoxLog.Items.Count)
            {
                var item = (LogItem)listBoxLog.Items[e.Index];
                using (var brush = new SolidBrush(item.Color))
                {
                    e.Graphics.DrawString(item.Text, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private class LogItem
        {
            public string Text { get; }
            public Color Color { get; }

            public LogItem(string text, Color color)
            {
                Text = text;
                Color = color;
            }

            public override string ToString() => Text;
        }
    }
}
