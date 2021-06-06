using EmployeeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure
{
    public class EmployeeContextSeed
    {
        public static void Seed(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if(context.Employees.Any() && context.Employees.Any())
            {
                return;
            }

            var positions = new List<Position>
            {
                new Position { ID = 1, PositionName = "Product Manager" },
                new Position { ID = 2, PositionName = "Production Manager" },
                new Position { ID = 3, PositionName = "General Manager" },
                new Position { ID = 4, PositionName = "HR Director" },
                new Position { ID = 5, PositionName = "Senior Editor" },
                new Position { ID = 6, PositionName = "Editor" }
            };

            context.Positions.AddRange(positions);
            
            var employees = new List<Employee>
            {
                new Employee { FirstName = "John", LastName = "Doe", Address = "123 Main St.", PhoneNumber = "(111) 222-3333", Position = positions.Where(p => p.ID == 1).FirstOrDefault() },
                new Employee { FirstName = "Roger", LastName = "Flynn", Address = "456 Eglinton St.", PhoneNumber = "(222) 333-4444", Position = positions.Where(p => p.ID == 2).FirstOrDefault() },
                new Employee { FirstName = "Alex", LastName = "Virasamy", Address = "789 Yonge St.", PhoneNumber = "(333) 444-5555", Position = positions.Where(p => p.ID == 3).FirstOrDefault() },
                new Employee { FirstName = "Kyle", LastName = "Pitt", Address = "901 Finch Ave.", PhoneNumber = "(444) 555-6666", Position = positions.Where(p => p.ID == 4).FirstOrDefault() },
                new Employee { FirstName = "Elizabeth", LastName = "James", Address = "234 Avenue Rd.", PhoneNumber = "(555) 666-7777", Position = positions.Where(p => p.ID == 5).FirstOrDefault() },
                new Employee { FirstName = "Shelly", LastName = "Bell", Address = "345 College St.", PhoneNumber = "(666) 777-8888", Position = positions.Where(p => p.ID == 6).FirstOrDefault() },
                new Employee { FirstName = "Martin", LastName = "Ziberman", Address = "567 Bloor St.", PhoneNumber = "(777) 888-9999", Position = positions.Where(p => p.ID == 6).FirstOrDefault() },
            };

            context.Employees.AddRange(employees);

            context.SaveChanges();

        }
    }
}
