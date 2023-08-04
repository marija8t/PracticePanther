using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Assignment1.Library.DTO;
using Assignment1.Library.Models;
using Assignment1.Library.Services;
using Assignment1.Models;

namespace Assignment2.MAUI.ViewModels
{
	public class TimeViewModel
	{

        public Time Model { get; set; }
        private EmployeeDTO employee;
        public EmployeeDTO Employee
        {
            get
            {
                return employee;
            }

            set
            {
                employee = value;
                if (employee != null)
                {
                    Model.EmployeeId = employee.Id;
                }
            }
        }
        public string EmployeeDisplay => Employee?.Name ?? string.Empty;
        private Project project;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string HoursDisplay
        {
            get
            {
                return Model.Hours.ToString();
            }

            set
            {
                if (decimal.TryParse(value, out decimal v))
                {
                    Model.Hours = v;
                }
            }
        }

        public Project Project
        {
            get
            {
                return project;
            }

            set
            {
                project = value;
                if (project != null)
                {
                    Model.ProjectId = project.Id;
                }
            }
        }
        public string ProjectDisplay => Project?.ShortName ?? string.Empty;

        public ObservableCollection<EmployeeDTO> Employees
            => new ObservableCollection<EmployeeDTO>(EmployeeService.Current.Employees);
        public ObservableCollection<Project> Projects
            => new ObservableCollection<Project>(ProjectService.Current.Projects);
        public TimeViewModel()
        {
            Model = new Time();
            SetupCommands();
        }

        public TimeViewModel(Time t)
        {
            Model = t;
            var employee = EmployeeService.Current.Get(t.EmployeeId);
            if (employee != null)
            {
                Employee = employee;
            }

            var project = ProjectService.Current.Get(t.ProjectId);
            if (project != null)
            {
                Project = project;
            }
            SetupCommands();
        }


        //---add
        public void AddOrUpdate()
        {

            TimeService.Current.AddOrUpdate(Model);
        }




        //Commands

        public void SetupCommands()
        {
            DeleteCommand = new Command(
                (t) => ExecuteDelete((t as TimeViewModel).Model));
            EditCommand = new Command(
                (t) => ExecuteEdit((t as TimeViewModel).Model.TimeId));
            

     
        }

        //constructors
      

        public TimeViewModel(int timeId)
        {
            var time = TimeService.Current.Get(timeId);
            if (time != null){
                Model = time;
                SetupCommands();
            }
        }

        //------------------------------------delete--------------------------------

        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(Time time)
        {
            TimeService.Current.Delete(time);
        }



//------------------------------------------------------EDIT------------------------------------------------------


        public ICommand EditCommand { get; private set; }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//TimeDetail?timeId={Model.TimeId}");
            //Shell.Current.GoToAsync($"//TimeDetail?timeId={id}");
        
        }



        private Time selectedTime;
        public Time SelectedTime
        {
            get { return selectedTime; }
            set
            {
                if (selectedTime != value)
                {
                    selectedTime = value;
                    NotifyPropertyChanged();
                }
            }
        }




    }

}


