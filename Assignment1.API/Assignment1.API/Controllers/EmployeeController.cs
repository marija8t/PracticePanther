using System;
using Assignment1.API.Database;
using Assignment1.API.EC;
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

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return FakeDatabase.Employees;
        }

        [HttpGet("/{id}")]
        public Employee GetId(int id)
        {
            return FakeDatabase.Employees.FirstOrDefault(e => e.Id == id) ?? new Employee();
        }

        [HttpDelete("Delete/{Id}")]
        public Employee? Delete(int id)
        {
            var employeeToDelete = FakeDatabase.Employees.FirstOrDefault(e => e.Id == id);
            if(employeeToDelete != null)
            {
                FakeDatabase.Employees.Remove(employeeToDelete);
            }
            return employeeToDelete;
        }

        [HttpPost]
        public Employee AddOrUpdate([FromBody] Employee employee)
        {
            return new EmployeeEC().AddOrUpdate(employee);
        }
    }
}

