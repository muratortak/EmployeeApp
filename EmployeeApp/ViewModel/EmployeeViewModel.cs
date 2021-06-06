using EmployeeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModel
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(Employee employee)
        {
            EmployeeID = employee.ID;
            FullName = $"{employee.FirstName} {employee.LastName}";
            Address = employee.Address;
            PhoneNumber = employee.PhoneNumber;
            PositionName = employee.Position.PositionName;
            PositionID = employee.PositionID;
        }
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
    }
}
