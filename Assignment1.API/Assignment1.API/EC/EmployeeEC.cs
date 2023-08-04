using System;
using Assignment1.API.Database;
using Assignment1.Library.DTO;
using Assignment1.Library.Models;
using Assignment1.Models;

namespace Assignment1.API.EC
{
	public class EmployeeEC
	{
		public EmployeeDTO AddOrUpdate(EmployeeDTO dto)
		{
			//if(dto.Id > 0)
			//{
			//	var employeeToUpdate
			//		= Filebase.Current.Employees
			//		.FirstOrDefault(e => e.Id == dto.Id);
			//	if(employeeToUpdate != null)
			//	{
			//                 Filebase.Current.Employees.Remove(employeeToUpdate);
			//	}
			//             Filebase.Current.Employees.Add(new Employee(dto));
			//}
			//else
			//{
			//	//dto.Id = Filebase.Current.LastEmployeeId + 1;
			//             Filebase.Current.Employees.Add(new Employee(dto));
			//}
			//return dto;

			Filebase.Current.AddOrUpdate(new Employee(dto));
			return dto;

		}

		public IEnumerable<EmployeeDTO> Search (string query = "")
		{
			return FakeDatabase.Employees.
				Where(e => e.Name.ToUpper()
				.Contains(query.ToUpper())).Take(1000)
				.Select(e => new EmployeeDTO(e));
        }

		public EmployeeDTO? Delete(int id)
		{
            var employeeToDelete = FakeDatabase.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                FakeDatabase.Employees.Remove(employeeToDelete);
            }
            return employeeToDelete != null ?
				 new EmployeeDTO(employeeToDelete) : null;
        }


		public EmployeeDTO? Get(int id)
		{
            var returnVal = FakeDatabase.Employees
                 .FirstOrDefault(e => e.Id == id)
                 ?? new Employee();

            return new EmployeeDTO(returnVal);
        }
	}
}

