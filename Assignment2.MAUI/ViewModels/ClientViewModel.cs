using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assignment1.Library.Services;
using Assignment1.Library.Models;
using Assignment1.Models;
using System.Windows.Input;

namespace Assignment2.MAUI.ViewModels
{
    public class ClientViewModel 
    {


        public Client Model { get; set; }

        public Project SelectedProject { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }


        public ICommand DeleteCommand { get; private set; }
        public ICommand EditProjectsCommand { get; private set; }

        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }




        private void SetupCommands()
        {
            DeleteCommand = new Command(
                    (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                    (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            AddProjectCommand = new Command(
                    (c) => ExecuteAddProject());
            ShowProjectsCommand = new Command(
                    (c) => ExecuteShowProjects((c as ClientViewModel).Model.Id));
            DeleteProjectCommand = new Command(
                    (c) => ExecuteDeleteProjects((c as ClientViewModel).Model.Id));
            CloseClientCommand = new Command(
                    (c) => ExecuteCloseClient((c as ClientViewModel).Model.Id));
            EditProjectCommand = new Command(
                    (c) => ExecuteEditProject());
            //CloseCommand = new Command(
            //        (c) => ExecuteCloseProjects((c as ClientViewModel).Model.Id));

            //take in the project id and moce executeeditproject into projectviewmodel
        }

        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            if(clientId == 0)
            {
                Model = new Client();
            }
            else
            {
                Model = ClientService.Current.Get(clientId);
               
            }
            SetupCommands();
            //new
            AddProjectCommand = new Command(ExecuteAddProject);
        }

        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();
        }


//--------------------------------------------EDIT CLIENT-------------------------------------------------------
        public ICommand EditCommand { get; private set; }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

//------------------------------------------------CLOSE CLIENT----------------------------------------------
        
        public ICommand CloseClientCommand { get; private set; }

        public void ExecuteCloseClient(int id)
        {
            
            var projects = ProjectService.Current.Projects.Where(p => p.ClientId == id);

            bool anyActiveProjects = projects.Any(p => p.IsActive);

            if (anyActiveProjects)
            {
                Application.Current.MainPage.DisplayAlert("Error", "All projects must be closed before closing the client.", "OK");
            }
            else
            {
                ClientService.Current.Delete(id);
                Application.Current.MainPage.DisplayAlert("Client Closed", "The client has been closed.", "OK");
            }
        }


//===========================================================================================================
//=                                        PROJECTS                                                         =
//===========================================================================================================
        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                //if this is a new client, we have no projects to return yet
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>();
                }
                return new ObservableCollection<ProjectViewModel>(ProjectService
                    .Current.Projects.Where(p => p.ClientId == Model.Id)
                    .Select(r => new ProjectViewModel(r)));
            }
        }

        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public ICommand ShowProjectsCommand { get; private set; }

        public void ExecuteShowProjects(int id)
        {
            Shell.Current.GoToAsync($"//Projects?clientId={id}");
        }
//--------------------------------------------------ADD-----------------------------------------------------------------
        public ICommand AddProjectCommand { get; private set; }


        public void ExecuteAddProject()
        {
            Model.IsActive = true;
            AddOrUpdate(); //save the client so that we have an id to link the project to
            //To do: if we cancel the creation of this client, we need to delete it on cancel.
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}");
        }

        public void AddOrUpdate()
        {
            if (Model.Id == 0)
                Model.IsActive = true;
                ClientService.Current.AddOrUpdate(Model);


        }

//--------------------------------------------------DELETE-------------------------------------------------------

        public ICommand DeleteProjectCommand { get; private set; }
        public void ExecuteDeleteProjects(int id)
        {
            ProjectService.Current.Delete(id);
            //RefreshProjects();
        }


//--------------------------------------------------EDIT-------------------------------------------------------


        public ICommand EditProjectCommand { get; private set; }

        public void ExecuteEditProject()
        {
            AddOrUpdate();
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}&projectId{0}");
        }




    }
}

