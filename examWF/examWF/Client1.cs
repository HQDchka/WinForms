using System.Windows.Forms;
using System;


namespace examWF
{
    public partial class Client1 : Form
    {
        public Client1()
        {
            InitializeComponent();
            MessageManager.OnMessageSent += ReceiveMessage;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxInput.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                MessageManager.SendMessage("[Client1] " + message);
                textBoxInput.Clear();
            }
        }

        private void ReceiveMessage(string message)
        {
            if (!message.StartsWith("[Client1]"))
                listBoxMessages.Items.Add(message);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MessageManager.OnMessageSent -= ReceiveMessage;

            if (Application.OpenForms.Count == 1)
                Application.Exit();

            base.OnFormClosed(e);
        }
    }

}