using System;
using System.Windows.Input;
using Assignment1.Library.Models;
using Assignment1.Library.Services;
using Assignment1.Models;

namespace Assignment2.MAUI.ViewModels
{
	public class EmployeeViewModel
	{
        public Employee Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public EmployeeViewModel(Employee employee)
        {
            Model = employee;
            SetupCommands();
        }

        public ICommand DeleteCommand { get; private set; }

        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as EmployeeViewModel).Model.Id));
            EditCommand = new Command(
                    (c) => ExecuteEdit((c as EmployeeViewModel).Model.Id));
        }
      

        public EmployeeViewModel(int employeeId)
        {
            if (employeeId == 0)
            {
                Model = new Employee();
            }
            else
            {
                Model = EmployeeService.Current.Get(employeeId);

            }
            SetupCommands();
        }

        public void AddOrUpdate()
        {
            EmployeeService.Current.AddOrUpdate(Model);
        }

        public EmployeeViewModel()
        {
            Model = new Employee();
            SetupCommands();
        }

//---------------------------------EDIT-----------------------------------------------------------


        public ICommand EditCommand { get; private set; }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={id}");
        }
    }
}

