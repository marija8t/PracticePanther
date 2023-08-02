using System;
using Assignment1.Models;
using Assignment1.Library.Services;
using Assignment1.Library.Models;

namespace Assignment1
{

    internal class Program
    {
        static void Main(String[] args)
        {
            //    while (true)
            //    {
            //        Console.WriteLine("C. Client Menu");
            //        Console.WriteLine("P. Project Menu");

            //        var choice = Console.ReadLine() ?? string.Empty;

            //        if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //list of client
            //            //var clients = new List<Client>();
            //            ClientMenu();

            //        }
            //        else if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //list of projects
            //            //var projects = new List<Project>();
            //            //var clients = new List<Client>();
            //            ProjectMenu();
            //        }

            //    }
            //}

            //static void ClientMenu()
            //{
            //    var myClientService = ClientService.Current;

            //    while (true)
            //    {
            //        Console.WriteLine("C. Create a client");
            //        Console.WriteLine("R. List a client");
            //        Console.WriteLine("U. Update a client");
            //        Console.WriteLine("D. Delete a client");
            //        Console.WriteLine("Q. Quit");
            //        //choice might be null(if they just hit enter) so need to check
            //        //if the thing on the right is null it return the left
            //        //?? string.Empty does the same thing as the code below
            //        //if (choice == null)
            //        //{
            //        //    choice = string.Empty;
            //        //}

            //        //OR

            //        var choice = Console.ReadLine() ?? string.Empty;

            //        //value comparison
            //        if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //create
            //            Console.WriteLine("ID: ");
            //            var Id = int.Parse(Console.ReadLine() ?? "0");

            //            //while(!int.TryParse(Console.ReadLine(), out int myInt)
            //            Console.WriteLine("Name: ");
            //            var name = Console.ReadLine();

            //            Console.WriteLine("Notes: ");
            //            var notes = Console.ReadLine();



            //            myClientService.Add(
            //                new Client
            //                {
            //                    Id = Id,
            //                    //instead of making name nullable( a client needs a name) guarantee that it has a value
            //                    Name = name ?? "John/ Jane Doe",
            //                    IsActive = true,
            //                    OpenDate = DateTime.Now

            //                }

            //            );


            //        }
            //        else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
            //        {

            //            myClientService.Read();

            //        }
            //        else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //update similar to delete
            //            //dont have to do all properties just show that you can update stuff

            //            Console.WriteLine("Which client should be updated?");
            //            myClientService.Read();
            //            var updateChoice = int.Parse(Console.ReadLine() ?? "0");

            //            //get pointer to find the student reference with id
            //            var clientToUpdate = myClientService.Get(updateChoice);
            //            if (clientToUpdate != null)
            //            {
            //                Console.WriteLine("What would you like to update?");
            //                Console.WriteLine("N. Name");
            //                Console.WriteLine("T. Notes");
            //                Console.WriteLine("I. ID");
            //                Console.WriteLine("S. Start Date");

            //                string M = Console.ReadLine() ?? string.Empty;

            //                if(M.Equals("N", StringComparison.InvariantCultureIgnoreCase))
            //                {
            //                    Console.WriteLine("What is the clients updated name?");
            //                    clientToUpdate.Name = Console.ReadLine() ?? "John/Jane Doe";
            //                }
            //                else if(M.Equals("T", StringComparison.InvariantCultureIgnoreCase))
            //                {
            //                    Console.WriteLine("What is the clients updated notes?");
            //                    clientToUpdate.Notes = Console.ReadLine() ?? "Do this";
            //                }
            //                else if (M.Equals("I", StringComparison.InvariantCultureIgnoreCase))
            //                {
            //                    Console.WriteLine("What is the clients updated Id?");
            //                    clientToUpdate.Id = int.Parse(Console.ReadLine() ?? "00000");
            //                }
            //                else if(M.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            //                {
            //                    Console.WriteLine("What is the client's updated date? (yyyy-MM-dd)");
            //                    string dateInput = Console.ReadLine() ?? "0-00-0000";

            //                    if (DateTime.TryParse(dateInput, out DateTime newDate))
            //                    {
            //                        clientToUpdate.OpenDate = newDate;
            //                        Console.WriteLine("Client's open date updated successfully.");
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine("Invalid date format. Update failed.");
            //                    }
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Invalid input");
            //                }
            //            }

            //        }
            //        else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //delete

            //            Console.WriteLine("Which client should be deleted?");
            //            myClientService.Read();
            //            var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

            //            //get pointer to find the student reference with id
            //            //the paranthesis is a linkq expression(first c is a temp name and represents each client in clients, next c.Id check if it matches deleteChoice, FirstOrDefault gets the first ID)
            //            myClientService.Delete(deleteChoice);

            //        }
            //        else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            break;
            //        }


            //        else
            //        {
            //            Console.WriteLine("Sorry, that functionality is not supported.");
            //        }
            //    }
            //}

            //static void ProjectMenu()
            //{
            //    var myClientService = ClientService.Current;
            //    var myProjectService = ProjectService.Current;

            //    while (true)
            //    {
            //        Console.WriteLine("C. Create a project");
            //        Console.WriteLine("R. List a peoject");
            //        Console.WriteLine("U. Update a project");
            //        Console.WriteLine("D. Delete a project");
            //        Console.WriteLine("L. Link a Project to a Client");
            //        Console.WriteLine("Q. Quit");

            //        var choice = Console.ReadLine() ?? string.Empty;

            //        //value comparison
            //        if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //create
            //            Console.WriteLine("ID: ");
            //            var Id = int.Parse(Console.ReadLine() ?? "0");

            //            //while(!int.TryParse(Console.ReadLine(), out int myInt)
            //            Console.WriteLine("ShortName: ");
            //            var name = Console.ReadLine();

            //            myProjectService.Add(
            //                new Project
            //                {
            //                    Id = Id,
            //                    //instead of making name nullable( a client needs a name) guarantee that it has a value
            //                    ShortName = name ?? "Project 0",
            //                    IsActive = true,
            //                    OpenDate = DateTime.Now
            //                }

            //            );


            //        }
            //        else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
            //        {

            //            myProjectService.Read();

            //        }
            //        else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //update similar to delete
            //            //dont have to do all properties just show that you can update stuff

            //            Console.WriteLine("Which project should be updated?");
            //            myProjectService.Read();
            //            var updateChoice = int.Parse(Console.ReadLine() ?? "0");


            //            var projectToUpdate = myProjectService.Get(updateChoice);
            //            if (projectToUpdate != null)
            //            {
            //                Console.WriteLine("What would you like to update?");
            //                Console.WriteLine("N. ShortName");
            //                Console.WriteLine("I. Id");
            //                Console.WriteLine("S. Start Date");

            //                string p = Console.ReadLine() ?? string.Empty;

            //                if(p.Equals("N", StringComparison.InvariantCultureIgnoreCase))
            //                {
            //                    Console.WriteLine("What is the project's updated name?");
            //                    projectToUpdate.ShortName = Console.ReadLine() ?? "Project 0";
            //                }
            //                else if(p.Equals("I", StringComparison.InvariantCultureIgnoreCase))
            //                {
            //                    Console.WriteLine("What is the updated Id");
            //                    projectToUpdate.Id = int.Parse(Console.ReadLine() ?? "0000");
            //                }
            //                else if(p.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            //                {

            //                    Console.WriteLine("What is the client's updated date? (yyyy-MM-dd)");
            //                    string dateInput = Console.ReadLine() ?? "0-00-0000";

            //                    if (DateTime.TryParse(dateInput, out DateTime newDate))
            //                    {
            //                        projectToUpdate.OpenDate = newDate;
            //                        Console.WriteLine("Client's open date updated successfully.");
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine("Invalid date format. Update failed.");
            //                    }

            //                }
            //                else
            //                {
            //                    Console.WriteLine("Invalid input.");
            //                }


            //            }

            //        }
            //        else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            //delete

            //            Console.WriteLine("Which project should be deleted?");
            //            myProjectService.Read();
            //            var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

            //            myProjectService.Delete(deleteChoice);

            //        }
            //        else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            break;
            //        }
            //        else if (choice.Equals("L", StringComparison.InvariantCultureIgnoreCase))
            //        {

            //            //link
            //            Console.WriteLine("Enter Project's ID");
            //            var ProjectId = int.Parse(Console.ReadLine() ?? "0");

            //            //get pointer to project

            //            var ProjectToLink = myProjectService.Get(ProjectId);
            //                                //projects.FirstOrDefault(p => p.Id == ProjectId);

            //            if (ProjectToLink != null)
            //            {
            //                Console.Write("Enter the client's Id to link: ");
            //                int clientId = int.Parse(Console.ReadLine() ?? "0");

            //                //get pointer to client to link
            //                var ClientToLink = myClientService.Get(clientId);
            //                //?
            //                if (ClientToLink != null)
            //                {
            //                    ProjectToLink.ClientId = clientId;
            //                    Console.WriteLine("Project linked to the client successfully.");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Client not found");
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Project not found");
            //            }

            //        }
            //        else
            //        {
            //            Console.WriteLine("Sorry, that functionality is not supported.");
            //        }
            //    }
            //}

            List<Client> clients = new List<Client>();
            List<Project> projects = new List<Project>();
            Console.WriteLine("Client Name: ");
            var name = Console.ReadLine() ?? string.Empty;

            var client = new Client
            {
                Name = name,
                Id = 1
            };

            Console.WriteLine("Project Name:");
            name = Console.ReadLine() ?? string.Empty;

            var proj = new Project
            {
                ShortName = name,
                Id = 1,
                ClientId = client.Id,
            };

            var proj2 = new Project
            {
                ShortName = $"{name}(1)",
                Id = 2,
                ClientId = client.Id,
            };


            clients.Add(client);
            projects.Add(proj);
            projects.Add(proj2);
        }
    }

        
}
