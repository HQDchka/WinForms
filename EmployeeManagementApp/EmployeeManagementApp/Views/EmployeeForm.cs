using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Views;

namespace EmployeeManagementApp
{
    public partial class EmployeeForm : Form, IEmployeeView
    {
        public EmployeeForm()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            buttonAdd.Click += (s, e) => AddEmployee?.Invoke();
            buttonEdit.Click += (s, e) => EditEmployee?.Invoke();
            buttonDelete.Click += (s, e) => DeleteEmployee?.Invoke();
            buttonSave.Click += (s, e) => SaveEmployee?.Invoke();
            buttonCancel.Click += (s, e) => CancelEdit?.Invoke();
            buttonSearch.Click += (s, e) => SearchEmployees?.Invoke();
            listBoxEmployees.SelectedIndexChanged += (s, e) => EmployeeSelected?.Invoke();
        }

        // Интерфейс IEmployeeView
        public string FirstName => textBoxFirstName.Text;
        public string LastName => textBoxLastName.Text;
        public string Position => textBoxPosition.Text;
        public string SalaryText => textBoxSalary.Text;

        public Employee SelectedEmployee => listBoxEmployees.SelectedItem as Employee;

        public event Action AddEmployee;
        public event Action EditEmployee;
        public event Action DeleteEmployee;
        public event Action SaveEmployee;
        public event Action CancelEdit;
        public event Action SearchEmployees;
        public event Action EmployeeSelected;

        public void DisplayEmployees(List<Employee> employees)
        {
            listBoxEmployees.DataSource = null;
            listBoxEmployees.DataSource = employees;
            listBoxEmployees.DisplayMember = "ToString";
        }

        public void ClearInputs()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxPosition.Text = "";
            textBoxSalary.Text = "";
        }

        public void SetFormMode(bool isEditMode)
        {
            buttonSave.Enabled = isEditMode;
            buttonCancel.Enabled = isEditMode;

            buttonAdd.Enabled = !isEditMode;
            buttonEdit.Enabled = !isEditMode;
            buttonDelete.Enabled = !isEditMode;

        }
    }
}
