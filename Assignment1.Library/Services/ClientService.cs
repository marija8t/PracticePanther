using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Assignment1.Library.Database;
using Assignment1.Models;

namespace Assignment1.Library.Services
{
	public class ClientService
	{


        public List<Client> Clients
        {
            get
            {
                return clients;
            }
        }

        private List<Client> clients;

        private static ClientService? instance;

        private static object _lock = new object();

        public static ClientService Current
		{
			get
			{
				lock (_lock)
				{
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                }
				return instance;
			}

		}

        private ClientService()
        {
            clients = new List<Client>
            {
                new Client{ Id = 1, Name = "Client 1"},
                new Client{ Id = 2, Name = "Client 2"},
                new Client{ Id = 3, Name = "Client 3"},
                new Client{ Id = 4, Name = "Client 4"},
                new Client{ Id = 5, Name = "Client 5"},
                new Client{ Id = 6, Name = "Client 6"},
                new Client{ Id = 7, Name = "Test 7"}
            };
        }


//------------------------------------DELETE------------------------------------------------------
        public void Delete(int id)
        {
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Clients.Remove(clientToDelete);
            }
        }

//------------------------------------ADD/EDIT------------------------------------------------------
        public void AddOrUpdate(Client c)
        {
            if (c.Id == 0)
            {
                //add
                c.Id = LastId + 1;
                Clients.Add(c);
            }

        }

//------------------------------------Functions------------------------------------------------------
        public Client? Get(int id)
        {
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        private int LastId
        {
            get
            {
                return Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
            }
        }

//------------------------------------Search------------------------------------------------------
        public List<Client> Search(string query)
        {
            return Clients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }




    }
}

