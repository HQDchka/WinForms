using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementApp.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();
        private int _nextId = 1;

        public List<Employee> GetAll() => _employees.ToList();

        public void Add(Employee employee)
        {
            employee.Id = _nextId++;
            _employees.Add(employee);
        }

        public void Update(Employee updated)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == updated.Id);
            if (employee != null)
            {
                employee.FirstName = updated.FirstName;
                employee.LastName = updated.LastName;
                employee.Position = updated.Position;
                employee.Salary = updated.Salary;
            }
        }

        public void Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
                _employees.Remove(employee);
        }

        public List<Employee> Search(string query)
        {
            query = query.ToLower();
            return _employees
                .Where(e => e.FirstName.ToLower().Contains(query)
                         || e.LastName.ToLower().Contains(query)
                         || e.Position.ToLower().Contains(query))
                .ToList();
        }
    }
}
