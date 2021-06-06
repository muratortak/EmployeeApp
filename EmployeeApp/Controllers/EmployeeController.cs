using EmployeeApp.Infrastructure;
using EmployeeApp.Model;
using EmployeeApp.Services;
using EmployeeApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;
        private readonly EmployeeService _service;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(EmployeeContext context, ILogger<EmployeeController> logger, EmployeeService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetEmp")]
        public IEnumerable<EmployeeViewModel> Get()
        {
            return _service.GetAllEmployees();
        }

        [HttpPost]
        [Route("Add")]
        public EmployeeViewModel Add([FromBody] EmployeeViewModel newEmployee)
        {
            // Validation can be added.
            return _service.SaveNewEmployee(newEmployee);
        }
    }
}
