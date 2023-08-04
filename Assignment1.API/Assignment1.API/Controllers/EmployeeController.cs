using System;
using Assignment1.API.Database;
using Assignment1.API.EC;
using Assignment1.Library.DTO;
using Assignment1.Library.Models;
using Assignment1.Library.Utilities;
using Assignment1.Models;
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
        public IEnumerable<EmployeeDTO> Get()
        {
            return new EmployeeEC().Search();
        }

        [HttpGet("/{id}")]
        public EmployeeDTO? GetId(int id)
        {
            return new EmployeeEC().Get(id);
        }

        [HttpDelete("Delete/{Id}")]
        public EmployeeDTO? Delete(int id)
        {
            return new EmployeeEC().Delete(id);
        }

        [HttpPost]
        public EmployeeDTO AddOrUpdate([FromBody] EmployeeDTO employee)
        {
            return new EmployeeEC().AddOrUpdate(employee);
        }

        [HttpPost("Search")]
        public IEnumerable<EmployeeDTO> Search([FromBody]QueryMessage query)
        {
            return new EmployeeEC().Search(query.Query);
           
        }
    }
}

