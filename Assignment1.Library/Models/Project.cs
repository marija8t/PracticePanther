using System;
using System.Xml.Linq;
using Assignment1.Library.Models;

namespace Assignment1.Models
{
	public class Project
	{
        //An Int property called Id
        public int Id { get; set; }
        //A DateTime property called OpenDate
        public DateTime OpenDate { get; set; }
        //A DateTime property called ClosedDate
        public DateTime ClosedDate { get; set; }
        //A Boolean property called IsActive
        public bool IsActive { get; set; }
        //A String property called ShortName
        public string? ShortName { get; set; }
        //A String property called LongName
        public string? LongName { get; set; }
        //An Int property called ClientId
        public int ClientId { get; set; }
        public IEnumerable<Bill> Bills { get; set; }

        //public Project()
        //{
        //    ShortName = string.Empty;
        //    LongName = string.Empty;
        //}

        public override string ToString()
        {
            return $"{Id}. {ShortName}";
        }
    }

}

