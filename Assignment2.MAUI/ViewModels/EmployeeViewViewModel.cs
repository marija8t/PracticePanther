using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assignment1.Library.Models;
using Assignment1.Library.Services;
using Assignment1.Models;
//using static Android.App.DownloadManager;

namespace Assignment2.MAUI.ViewModels
{
	public class EmployeeViewViewModel : INotifyPropertyChanged
    {
        private Employee SelectedEmployee { get; set; }


        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                return
                    new ObservableCollection<EmployeeViewModel>
                    (EmployeeService
                        .Current.Employees.Where(e => e.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty))
                        .Select(e => new EmployeeViewModel(e)).ToList());
            }

        }


        public EmployeeViewViewModel()
        {
            SelectedEmployee = new Employee();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(Employees));
        }



//------------------------------------SEARCH------------------------------------------------------
        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged(nameof(Employees));

        }
//------------------------------------DELETE------------------------------------------------------
        public void Delete()
        {
            if (SelectedEmployee != null)
            {
                ClientService.Current.Delete(SelectedEmployee.Id);
                SelectedEmployee = null;
                NotifyPropertyChanged(nameof(Employees));
                NotifyPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Employees));
        }








//------------------------------------EDIT------------------------------------------------------

        public void Edit()
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={SelectedEmployee?.Id ?? 0}");
        }
    }



}

