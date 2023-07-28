using System;
namespace Assignment1.Models
{
	public class Client
	{
        //An Int property called Id
        public int Id { get; set; }
        //A DateTime property called OpenDate
        public DateTime OpenDate { get; set; }
        //A DateTime property called ClosedDate
        public DateTime ClosedDate { get; set; }
        //A Boolean property called IsActive
        public bool IsActive { get; set; }
        //A String property called Name
        public string Name { get; set; }
        //A String property called Notes
        public string Notes { get; set; }


        //new
        public Project ProjectId { get; set; }

        public Client()
        {
            Name = string.Empty;
            Notes = string.Empty;
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

