using System;
using System.Reflection;
using Assignment1.Library.Models;
using Assignment1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment1.Library.Services
{
	public class TimeService
	{
        public List<Time> Times
        {
            get
            {
                return times;
            }
        }

        private List<Time> times;

        private static TimeService? instance;

        private static object _lock = new object();

        public static TimeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new TimeService();
                    }
                }
                return instance;
            }

        }

        private TimeService()
        {
            times = new List<Time>
            {
                new Time{TimeId = 1, EmployeeId = 1, ProjectId = 1, Hours=2, Narrative = "TEST TIME ENTRY"},
                //new Time{TimeId = 2, EmployeeId = 1, ProjectId = 1, Hours=5, Narrative = "ANOTHER TIME ENTRY"},
                
            };
     
        }



        //get
        public Time? Get(int id)
        {
            return Times.FirstOrDefault(c => c.TimeId == id);
        }




        //------------------------------------EDIT----------------------------------------------------
        public void EditTime(Time updatedTime)
        {
            Time? existingTime = times.FirstOrDefault(t => t.EmployeeId == updatedTime.EmployeeId && t.ProjectId == updatedTime.ProjectId);
            if (existingTime != null)
            {
                existingTime.Date = ValidateDateTime(updatedTime.Date);
                existingTime.Hours = ValidateHours(updatedTime.Hours);
                existingTime.Narrative = updatedTime.Narrative;
                existingTime.ProjectId = updatedTime.ProjectId;
                existingTime.EmployeeId = updatedTime.EmployeeId;
            }
        }

        private DateTime ValidateDateTime(DateTime dateTime)
        {
            // Check if the DateTime is in the future
            if (dateTime > DateTime.Now)
            {
                // Set the DateTime to the current date and time
                dateTime = DateTime.Now;
            }

            // Check if the DateTime is in the past (e.g., beyond a specific range)
            if (dateTime < DateTime.Now.AddYears(-1))
            {
                // Set the DateTime to the minimum allowed date (e.g., one year ago)
                dateTime = DateTime.Now.AddYears(-1);
            }

            // Return the validated DateTime
            return dateTime;
        }


        private decimal ValidateHours(decimal hours)
        {
            // Check if the hours are negative
            if (hours < 0)
            {
                // Set the hours to zero
                hours = 0;
            }

            // Check if the hours exceed a certain limit (e.g., 24 hours)
            if (hours > 24)
            {
                // Set the hours to the maximum allowed limit
                hours = 24;
            }

            // Return the validated hours
            return hours;
        }




        public event EventHandler<string>? InvalidTimeAdded;

        public Time AddOrUpdate(Time t)
        {
            if (t.ProjectId <= 0 || t.EmployeeId <= 0)
            {

                // Raise the custom event with an error message
                InvalidTimeAdded?.Invoke(this, "Cannot add time without project id and employee id.");
                return t; // Return the invalid Time object if needed
            }
            times.Add(t);
            return t;
        }




        //------------------------------------DELETE----------------------------------------------------
        public void Delete(Time time)
        {
            times?.Remove(time);
        }


  

    }
}

