using System;
using Assignment1.Library.Models;
using Assignment1.Models;

namespace Assignment1.Library.Services
{
	public class EmployeeService
	{
        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }

        private List<Employee> employees;

        private static EmployeeService? instance;

        private static object _lock = new object();

        public static EmployeeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeService();
                    }
                }
                return instance;
            }

        }



        private EmployeeService()
        {
            employees = new List<Employee>
            {
                new Employee{ Id = 1, Name = "Mary Jane", Rate = 20}, 
                new Employee{ Id = 2, Name = "Bob Burgers", Rate = 20},
                new Employee{ Id = 3, Name = "Lisa"},
                new Employee{ Id = 4, Name = "John Smith"},
                new Employee{ Id = 5, Name = "Tammy"},
                new Employee{ Id = 6, Name = "Gene"},
                new Employee{ Id = 7, Name = "Marija"}
            };
        }


//------------------------------------IDFunctions------------------------------------------------------
        public Employee? Get(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }

        private int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;
            }
        }

//------------------------------------DELETE------------------------------------------------------
        public void Delete(int id)
        {
            var employeeToDelete = Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
        }

//------------------------------------ADD/EDIT------------------------------------------------------
        public void AddOrUpdate(Employee e)
        {
            if (e.Id == 0)
            {
                //add
                e.Id = LastId + 1;
                Employees.Add(e);
            }

        }

    }
}



