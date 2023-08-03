using System;
using Assignment1.Library.Models;
using Assignment1.Models;

namespace Assignment1.API.Database
{
	public static class FakeDatabase
	{
        public static List<Employee> Employees = new List<Employee>
        {
                new Employee{ Id = 1, Name = "Mary Jane", Rate = 20},
                new Employee{ Id = 2, Name = "Bob Burgers", Rate = 20},
                new Employee{ Id = 3, Name = "Lisa"},
                new Employee{ Id = 4, Name = "John Smith"},
                new Employee{ Id = 5, Name = "Tammy"},
                new Employee{ Id = 6, Name = "Gene"},
                new Employee{ Id = 7, Name = "Marija"}

        };

        public static int LastEmployeeId
            => Employees.Any() ? Employees.Select(c => c.Id).Max() : 0;

    }
}

