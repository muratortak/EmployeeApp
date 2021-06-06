using EmployeeApp.Infrastructure;
using EmployeeApp.Model;
using EmployeeApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class EmployeeService
    {
        private readonly EmployeeContext _context;
        private readonly ILogger _logger;

        public EmployeeService(EmployeeContext context, ILogger<EmployeeService> logger)
        {
            _context = context ?? throw new Exception(nameof(EmployeeContext));
            _logger = logger;
        }

        // Can be async
        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            _logger.LogInformation($"Begin call to GetAllEmployees for all employees");

            var employees = _context.Employees.Include("Position").ToList();
            var employeeViewModels = new List<EmployeeViewModel>();

            foreach (Employee employee in employees)
            {
                employeeViewModels.Add(new EmployeeViewModel(employee));
            }

            return employeeViewModels;
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            _logger.LogInformation($"Begin call to GetEmployeeById for employee {id}", id);

            if(id <= 0)
            {
                return null;
            }

            var employee = _context.Employees.SingleOrDefault(e => e.ID == id);

            if(employee != null)
            {
                return new EmployeeViewModel(employee);
            }

            return null;
        }

        public EmployeeViewModel SaveNewEmployee(EmployeeViewModel newEmployee)
        {
            _logger.LogInformation($"Begin call to SaveNewEmployee");

            if (string.IsNullOrEmpty(newEmployee.FullName))
            {
                return null;
            }

            string firstName = newEmployee.FullName.Split(" ").FirstOrDefault().Trim();
            string lastName = newEmployee.FullName.Replace($"{firstName }", "").Trim();
            Employee savedEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Address = newEmployee.Address,
                PhoneNumber = newEmployee.PhoneNumber,
                Position = _context.Positions.Where(p => p.ID == newEmployee.PositionID).FirstOrDefault()
            };

            _context.Employees.Add(savedEmployee);

            _context.SaveChanges();

            EmployeeViewModel returnModel = new EmployeeViewModel(savedEmployee);

            return returnModel;
        }
    }
}
