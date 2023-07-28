using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Assignment1.Library.Models;
using Assignment1.Library.Services;
using Assignment1.Models;
using System.Linq;
using System.Collections.Generic;

namespace Assignment2.MAUI.ViewModels
{
	public class BillViewModel : INotifyPropertyChanged
	{
        public Bill Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }


        //constructors
        public BillViewModel(Bill bill)
        {
            Model = bill;
            SetupCommands();

        }

        private int projectId;
        public BillViewModel(int projectId)
        {
            this.projectId = projectId;
            Model = new Bill();
            var timeEntries = TimeService.Current.Times
                .Where(t => t.ProjectId == projectId)
                .ToList();
            //Model.TotalAmount = CalculateAmount(timeEntries, projectId);
            Model.DueDate = DateTime.Now.AddDays(30); // Set due date to 30 days from now
            SetupCommands();
        }

        //AddDays(30) for due date

        public BillViewModel(List<Time> timeEntries)
        {
            Model = new Bill();
            //Model.TotalAmount = CalculateAmount(timeEntries);
            Model.DueDate = DateTime.Now.AddDays(30); // Set due date to 30 days from now
            SetupCommands();
        }

        public BillViewModel()
        {
        }



        //uncommented refreshbills
        public void RefreshBills()
        {
            NotifyPropertyChanged(nameof(Times));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public ICommand CalculateAmountCommand { get; private set; }
        private void ExecuteTotalAmount()
        {
           
            // Use the projectId field here to get the filtered time entries
            ObservableCollection<TimeViewModel> selectedTimeViewModels = GetFilteredTimeEntriesForProject(projectId);

            // Convert the ObservableCollection<TimeViewModel> to List<Time>
            List<Time> selectedTimeEntries = selectedTimeViewModels.Select(t => t.Model).ToList();

            DateTime dueDate = GetSelectedDueDate(); // Implement this method based on how you select the due date

            // Create the bill using the BillService
            BillService.Current.CreateBill(selectedTimeEntries, dueDate, projectId);

            Shell.Current.GoToAsync($"//ProjectDetail?projectId={projectId}");

        }

        public ObservableCollection<TimeViewModel> GetFilteredTimeEntriesForProject(int projectId)
        {
            return new ObservableCollection<TimeViewModel>(
                Times.Where(t => t.Model.ProjectId == projectId)
                     .Select(t => new TimeViewModel(t.Model)));
        }

      
        public ObservableCollection<TimeViewModel> Times
        {


            get
            {
                // Use the TimeService directly to filter the time entries
                var timeEntries = TimeService.Current.Times
                    .Where(t => t.ProjectId == projectId)
                    .ToList();
                return new ObservableCollection<TimeViewModel>(timeEntries.Select(t => new TimeViewModel(t)));
            }
            set { }



        }

        private ObservableCollection<TimeViewModel> selectedTimeEntries;
        public ObservableCollection<TimeViewModel> SelectedTimeEntries
        {
            get { return selectedTimeEntries; }
            set
            {
                selectedTimeEntries = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                NotifyPropertyChanged();
            }
        }

        // Implement the GetSelectedTimeEntries method
        public ObservableCollection<TimeViewModel> GetSelectedTimeEntries(int projectId)
        {
            // Call the FilterTimeEntries method in TimeViewViewModel to filter the time entries
            return TimeViewViewModel.Current.FilterTimeEntries(projectId);
        }

        // Implement the GetSelectedDueDate method
        private DateTime GetSelectedDueDate()
        {
            return SelectedDate;
        }


        public void SetupCommands()
        {
            CalculateAmountCommand = new Command(ExecuteTotalAmount);
    
        }
    }
}

