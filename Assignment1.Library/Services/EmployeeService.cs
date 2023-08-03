using System;
using Assignment1.Library.Models;
using Assignment1.Models;
using Newtonsoft.Json;

using Assignment1.Library.Utilities;

namespace Assignment1.Library.Services
{
	public class EmployeeService
	{
        private List<Employee> employees = new List<Employee>();

        public List<Employee> Employees
        {
            get
            {
                return employees ?? new List<Employee>();
            }
        }

        //private List<Employee> employees;

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
            var response = new WebRequestHandler()
                .Get("/Employee")
                .Result;
            employees = JsonConvert
                .DeserializeObject<List<Employee>>(response) ?? new List<Employee>();
        
        }


        //------------------------------------IDFunctions------------------------------------------------------
        public Employee? Get(int id)
        {
            //var response = new WebRequestHandler()
            //    .Get($"/Employee/GetEmployees/{id}")
            //    .Result;
            //var employee = JsonConvert
            //        .DeserializeObject<Employee>(response);
            return employees.FirstOrDefault(e => e.Id == id);
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
            //as webrequesthandler
            var employeeToDelete = Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
        }

//------------------------------------ADD/EDIT------------------------------------------------------
        public void AddOrUpdate(Employee e)
        {
            var response = new WebRequestHandler().Post("/Employee", e).Result;

            var myUpdatedEmployee = JsonConvert.DeserializeObject<Employee>(response);
            if (myUpdatedEmployee != null)
            {
                var existingEmployee = employees.FirstOrDefault(c => c.Id == myUpdatedEmployee.Id);
                if (existingEmployee == null)
                {
                    employees.Add(myUpdatedEmployee);
                }
                else
                {
                    var index = employees.IndexOf(existingEmployee);
                    employees.RemoveAt(index);
                    employees.Insert(index, myUpdatedEmployee);
                }
            }
        }

    }
}



