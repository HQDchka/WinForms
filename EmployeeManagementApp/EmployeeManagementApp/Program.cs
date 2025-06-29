using System;
using System.Windows.Forms;
using EmployeeManagementApp.Views;
using EmployeeManagementApp.Presenters;

namespace EmployeeManagementApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new EmployeeForm();
            var presenter = new EmployeePresenter(form);

            Application.Run(form);
        }
    }
}
