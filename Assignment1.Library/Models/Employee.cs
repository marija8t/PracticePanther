using System;
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
    }
}

