using System;
using Assignment1.Library.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assignment1.Library.Services;
using System.Collections.ObjectModel;
using System.Linq;
using Assignment1.Models;

namespace Assignment2.MAUI.ViewModels
{
	public class TimeViewViewModel : INotifyPropertyChanged
	{
        private Time SelectedTime { get; set; }


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

        private decimal selectedHours;
        public decimal SelectedHours
        {
            get { return selectedHours; }
            set
            {
                selectedHours = value;
                NotifyPropertyChanged();
            }
        }



        //------------------------------------EDIT------------------------------------------------------



        public void Edit()
        {
            //Shell.Current.GoToAsync("//TimeDetail");
            Shell.Current.GoToAsync($"//TimeDetail?timeId={SelectedTime?.TimeId ?? 0}");
        }








        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                return new ObservableCollection<TimeViewModel>
                    (TimeService.Current.Times.Select(t => new TimeViewModel(t)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshTimes()
        {
            NotifyPropertyChanged("Times");
        }





        //--------------------------new------------------------
        public ObservableCollection<TimeViewModel> FilterTimeEntries(int projectId)
        {
            
            return new ObservableCollection<TimeViewModel>(
                TimeService.Current.Times
                    .Where(t => t.ProjectId == projectId)
                    .Select(t => new TimeViewModel(t)));
        }

        // Create a property to hold the reference of TimeViewViewModel
        public static TimeViewViewModel Current { get; private set; }

        // Update the constructor to set the Current property
        public TimeViewViewModel()
        {
            Current = this;
            SelectedTime = new Time();
            SelectedDate = DateTime.Now;
            SelectedHours = 0;
            RefreshTimes();
        }



        public ObservableCollection<TimeViewModel> GetFilteredTimeEntriesForProject(int projectId)
        {
            return new ObservableCollection<TimeViewModel>(
                Times.Where(t => t.Model.ProjectId == projectId)
                     .Select(t => new TimeViewModel(t.Model)));
        }



    }
}

