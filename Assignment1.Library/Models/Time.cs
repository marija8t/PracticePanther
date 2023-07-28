using System;
using System.Security.Cryptography.X509Certificates;
using Assignment1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment1.Library.Models
{
	public class Time
	{
		public DateTime Date { get; set; }

		public string? Narrative { get; set; }

		public decimal Hours { get; set; }

		public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public int TimeId { get; set; }

        public override string ToString()
        {
            return $"Date: {Date}, Hours: {Hours}";
        }

    }
}

