using System;
using Assignment1.Library.Models;
using Assignment1.Models;

namespace Assignment1.Library.DTO
{
	public class EmployeeDTO
	{
        public EmployeeDTO()
        {
            Name = string.Empty;
            Rate = 1;
      
        }
        public EmployeeDTO(Employee e)
        {
            this.Id = e.Id;
            this.Name = e.Name;
            Rate = e.Rate;
 
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}

