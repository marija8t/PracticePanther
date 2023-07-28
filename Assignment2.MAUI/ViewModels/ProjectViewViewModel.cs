using System;
using Assignment1.Library.Services;
using Assignment1.Models;
using System.Collections.ObjectModel;
using Assignment1.Library.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment2.MAUI.ViewModels
{
	public class ProjectViewViewModel
	{

        private Project SelectedProject { get; set; }
        public Client Client { get; set; }
        public ObservableCollection<Project> Projects
        {
            get
            {
                if (Client == null || Client.Id == 0)
                {
                    return new ObservableCollection<Project>
                    (ProjectService.Current.Projects);
                }
                return new ObservableCollection<Project>
                    (ProjectService.Current.Projects
                    .Where(p => p.ClientId == Client.Id));
            }
        }
        public ProjectViewViewModel(int clientId)
        {
            if (clientId > 0)
            {
                Client = ClientService.Current.Get(clientId);
            }
            else
            {
                Client = new Client();
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }


        //-------------------------------------DELETE--------------------------------------------------
        public void Delete()
        {
            if (SelectedProject != null)
            {
                ProjectService.Current.Delete(SelectedProject.Id);
                SelectedProject = null;
                NotifyPropertyChanged(nameof(Projects));
                NotifyPropertyChanged(nameof(SelectedProject));

            }
        }



        public void Edit()
        {
            Shell.Current.GoToAsync($"//ProjectDetail?projectId={SelectedProject?.Id ?? 0}");
        }
    }
}

