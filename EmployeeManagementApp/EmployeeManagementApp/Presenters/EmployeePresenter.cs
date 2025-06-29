using EmployeeManagementApp.Models;
using EmployeeManagementApp.Views;
using System;
using System.Windows.Forms;

namespace EmployeeManagementApp.Presenters
{
    public class EmployeePresenter
    {
        private readonly IEmployeeView _view;
        private readonly IEmployeeRepository _repository;
        private Employee _editingEmployee;

        public EmployeePresenter(IEmployeeView view)
        {
            _view = view;
            _repository = new EmployeeRepository();

            _view.AddEmployee += OnAddEmployee;
            _view.EditEmployee += OnEditEmployee;
            _view.DeleteEmployee += OnDeleteEmployee;
            _view.SaveEmployee += OnSaveEmployee;
            _view.CancelEdit += OnCancelEdit;
            _view.SearchEmployees += OnSearchEmployees;
            _view.EmployeeSelected += OnEmployeeSelected;

            RefreshView();
        }

        private void RefreshView()
        {
            _view.DisplayEmployees(_repository.GetAll());
            _view.ClearInputs();
            _view.SetFormMode(false);
        }

        private void OnAddEmployee()
        {
            try
            {
                var employee = CreateFromView();
                _repository.Add(employee);
                RefreshView();
            }
            catch (FormatException)
            {
                ShowError("Ошибка ввода зарплаты.");
            }
        }

        private void OnEditEmployee()
        {
            _editingEmployee = _view.SelectedEmployee;
            if (_editingEmployee != null)
            {
                _view.SetFormMode(true);
            }
        }

        private void OnDeleteEmployee()
        {
            var employee = _view.SelectedEmployee;
            if (employee != null)
            {
                _repository.Delete(employee.Id);
                RefreshView();
            }
        }

        private void OnSaveEmployee()
        {
            if (_editingEmployee == null) return;

            try
            {
                var updated = CreateFromView();
                updated.Id = _editingEmployee.Id;
                _repository.Update(updated);
                _editingEmployee = null;
                RefreshView();
            }
            catch (FormatException)
            {
                ShowError("Ошибка ввода зарплаты.");
            }
        }

        private void OnCancelEdit()
        {
            _editingEmployee = null;
            RefreshView();
        }

        private void OnSearchEmployees()
        {
            var query = _view.FirstName + " " + _view.LastName + " " + _view.Position;
            var result = _repository.Search(query.Trim());
            _view.DisplayEmployees(result);
        }

        private void OnEmployeeSelected()
        {
            var emp = _view.SelectedEmployee;
            if (emp != null)
            {
            }
        }

        private Employee CreateFromView()
        {
            return new Employee
            {
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                Position = _view.Position,
                Salary = decimal.Parse(_view.SalaryText)
            };
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
