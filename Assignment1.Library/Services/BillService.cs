using System;
using System.Reflection;
using Assignment1.Library.Models;
using Assignment1.Models;


namespace Assignment1.Library.Services
{
	public class BillService
	{
        public List<Bill> Bills
        {
            get
            {
                return bills;
            }
        }

        private List<Bill> bills;

        private static BillService? instance;

        private static object _lock = new object();

        public static BillService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new BillService();
                    }
                }
                return instance;
            }

        }
         
        //default list to test
        private BillService()
        {
            bills = new List<Bill>
            {
                new Bill{ BillId = 1, ProjectId = 1, DueDate = DateTime.Now, TotalAmount = 50},
              
            };
        }

         
        //getter
        public Bill? Get(int id)
        {
            return Bills.FirstOrDefault(c => c.BillId == id);
        }

        //new
        public int GetProjectId(int projectId)
        {
            if (Bills != null)
            {
                var bill = Bills.FirstOrDefault(c => c.BillId == projectId);
                if(bill != null)
                {
                    return bill.ProjectId;
                }
            }
            return 0;
        }



        //----------------------NEW------------------------
        public void CreateBill(List<Time> timeEntries, DateTime dueDate, int projectId)
        {
            decimal totalAmount = CalculateTotalAmount(timeEntries);
            Bill bill = new Bill { TotalAmount = totalAmount, DueDate = dueDate, ProjectId = projectId };
            bills.Add(bill);
        }

        private decimal CalculateTotalAmount(List<Time> timeEntries)
        {
            decimal totalAmount = 0;

            foreach (var timeEntry in timeEntries)
            {
                Employee employee = GetEmployeeById(timeEntry.EmployeeId);
                if (employee != null)
                {
                    totalAmount += timeEntry.Hours * employee.Rate;
                }
            }

            

            return totalAmount;
        }

        private Employee GetEmployeeById(int employeeId)
        {
            
            return EmployeeService.Current.Get(employeeId);
        }
    }
}

