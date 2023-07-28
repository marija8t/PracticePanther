using System;
using Assignment1.Library.Models;
using Assignment1.Models;

namespace Assignment1.Library.Database
{
	public static class ClientDatabase
	{
        private static List<Client> people = new List<Client>();
        public static List<Client> People
        {
            get
            {
                return people;
            }
        }

        //static ClientDatabase()
        //{
        //    // Add default clients to the database
        //    people.Add(new Client { Id = 1, Name = "Marija Travoric" });
        //    people.Add(new Client { Id = 2, Name = "Sue Jones" });
        //    people.Add(new Client { Id = 3, Name = "Anna Beth" });
        //    people.Add(new Client { Id = 4, Name = "Nick Jonas" });
        //    people.Add(new Client { Id = 5, Name = "Bob Ross" });
        //    people.Add(new Client { Id = 6, Name = "Rob Bob" });
        //}
    }
}

