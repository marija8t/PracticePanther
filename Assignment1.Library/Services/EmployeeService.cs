using System;
using Assignment1.Library.Models;
using Assignment1.Models;
using Newtonsoft.Json;

using Assignment1.Library.Utilities;
using Assignment1.Library.DTO;

namespace Assignment1.Library.Services
{
	public class EmployeeService
	{
        private List<EmployeeDTO> employees;

        public List<EmployeeDTO> Employees
        {
            get
            {
                return employees ?? new List<EmployeeDTO>();
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
                .DeserializeObject<List<EmployeeDTO>>(response)
                ?? new List<EmployeeDTO>();
        
        }


//------------------------------------IDFunctions------------------------------------------------------
        public EmployeeDTO? Get(int id)
        {

            return employees.FirstOrDefault(e => e.Id == id);
        }


//------------------------------------DELETE------------------------------------------------------
        public void Delete(int id)
        {
            var response = new WebRequestHandler().Delete($"/Employee/Delete/{id}").Result;
            var employeeToDelete = Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
        }

//------------------------------------ADD/EDIT------------------------------------------------------
        public void AddOrUpdate(EmployeeDTO e)
        {
            var response = new WebRequestHandler().Post("/Employee", e).Result;

            var myUpdatedEmployee = JsonConvert.DeserializeObject<EmployeeDTO>(response);
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

//--------------------------------------------SEARCH------------------------------------------------------
        public IEnumerable<EmployeeDTO> Search(string query)
        {
            return Employees
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }
    }
}



