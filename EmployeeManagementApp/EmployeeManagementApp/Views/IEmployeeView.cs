using System;
using System.Collections.Generic;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Views
{
    public interface IEmployeeView
    {
        string FirstName { get; }
        string LastName { get; }
        string Position { get; }
        string SalaryText { get; }

        Employee SelectedEmployee { get; }

        void DisplayEmployees(List<Employee> employees);
        void ClearInputs();
        void SetFormMode(bool isEditMode);

        event Action AddEmployee;
        event Action EditEmployee;
        event Action DeleteEmployee;
        event Action SaveEmployee;
        event Action CancelEdit;
        event Action SearchEmployees;
        event Action EmployeeSelected;
    }
}
