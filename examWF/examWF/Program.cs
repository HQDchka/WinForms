using System;
using System.Windows.Forms;

namespace examWF
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Client1 client1 = new Client1();
            Client2 client2 = new Client2();
            client1.Show();
            client2.Show();
            Application.Run();
        }
    }
    public static class MessageManager
    {
        public delegate void MessageSentHandler(string message);
        public static event MessageSentHandler OnMessageSent;

        public static void SendMessage(string message)
        {
            OnMessageSent?.Invoke(message);
        }
    }

}
