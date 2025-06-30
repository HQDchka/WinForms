using System;
using System.Windows.Forms;
namespace examWF
{
    public partial class Client2 : Form
    {
        public Client2()
        {
            InitializeComponent();
            MessageManager.OnMessageSent += ReceiveMessage;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxInput.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                MessageManager.SendMessage("[Client2] " + message);
                textBoxInput.Clear();
            }
        }

        private void ReceiveMessage(string message)
        {
            if (!message.StartsWith("[Client2]"))
                listBoxMessages.Items.Add(message);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MessageManager.OnMessageSent -= ReceiveMessage;
            base.OnFormClosed(e);
        }
    }

}
