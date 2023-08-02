using System;
using Assignment1.API.Database;
using Assignment1.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.API.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet ("GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            return FakeDatabase.Employees;
        }

        [HttpGet("GetEmployees/{Id}")]
        public Employee GetId(int id)
        {
            return FakeDatabase.Employees.FirstOrDefault(e => e.Id == id) ?? new Employee();
        }
    }
}

