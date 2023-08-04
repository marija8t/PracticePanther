using Assignment1.Models;
using Newtonsoft.Json;
using Assignment1.API.EC;
using Assignment1.Library.Models;

namespace Assignment1.API.Database
{
    public class Filebase
    {
        private string _root;

        private string _employeeRoot;
        private static Filebase? _instance;


        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"/Users/temp";
            
            _employeeRoot = $"{_root}/Employees";
   
          
        }
        private int LastEmployeeId => Employees.Any() ? Employees.Select(c => c.Id).Max() : 0;

        public Employee AddOrUpdate(Employee e)
        {
            //set up a new Id if one doesn't already exist
            if (e.Id <= 0)
            {
                e.Id = LastEmployeeId + 1;
            }

            var path = $"{_employeeRoot}/{e.Id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(e));

            //return the item, which now has an id
            return e;
        }

        public List<Employee> Employees
        {
            get
            {
                var root = new DirectoryInfo(_employeeRoot);
                var _employees = new List<Employee>();
                foreach (var todoFile in root.GetFiles())
                {
                    var path = todoFile.FullName;
                    var content = File.ReadAllText(path);
                    try
                    {
                        var todo = JsonConvert.
                             DeserializeObject<Employee>
                            (content);

                        if (todo != null)
                        {
                            _employees.Add(todo);
                        }
                    } catch (Exception)
                    {
                        File.Delete(path);
                    }
                }
                return _employees;
            }
        }



        public bool Delete(string id)
        {
            var path = $"{_employeeRoot}/{id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }
    }

}
