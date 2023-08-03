using System;
using Assignment1.API.Database;
using Assignment1.Library.Models;

namespace Assignment1.API.EC
{
	public class EmployeeEC
	{
		public Employee AddOrUpdate(Employee employee)
		{
			if(employee.Id > 0)
			{
				var employeeToUpdate
					= FakeDatabase.Employees
					.FirstOrDefault(e => e.Id == employee.Id);
				if(employeeToUpdate != null)
				{
					FakeDatabase.Employees.Remove(employeeToUpdate);
				}
				FakeDatabase.Employees.Add(employee);
			}
			else
			{
				employee.Id = FakeDatabase.LastEmployeeId + 1;
				FakeDatabase.Employees.Add(employee);
			}
			return employee;

		}

		public IEnumerable<Employee> Search (string query)
		{
            return FakeDatabase.Employees.
                Where(e => e.Name.ToUpper()
                .Contains(query.ToUpper()));
        }
	}
}

