using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Assignment1.Library.Models
{
	public class Bill
	{
        //shows the amount of the bill 
        public decimal TotalAmount { get; set; }
        //shows the date the bill is due
        public DateTime DueDate { get; set; }

        public int BillId { get; set; }

        public int ProjectId { get; set; }

 

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            //return $"Due Date: {DueDate}. Total Amount: {TotalAmount}";
            return $"{DueDate}. {TotalAmount}";
        }
    }
}

