using System;
using Assignment1.Library.DTO;

namespace Assignment1.Library.Models
{
	public class Employee
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Rate { get; set; }



        public Employee()
        {
            Name = string.Empty;
            
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public Employee(EmployeeDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Rate = dto.Rate;
           
        }

        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
        public string? Property3 { get; set; }
        public string? Property4 { get; set; }
        public string? Property5 { get; set; }
        public string? Property6 { get; set; }
        public string? Property7 { get; set; }
        public string? Property8 { get; set; }
        public string? Property9 { get; set; }
        public string? Property10 { get; set; }
    }
}

