using System;
using Assignment1.Library.Services;
using Assignment1.Models;
using System.Windows.Input;
using Assignment2.MAUI.Views;

using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using Assignment1.Library.Models;

namespace Assignment2.MAUI.ViewModels
{
    public class ProjectViewModel
    {
        public Project Model { get; set; }


        public ICommand AddCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }

        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        private void ExecuteAdd()
        {
            ProjectService.Current.Add(Model);
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }




        private void ExecuteTimer()
        {
            var window = new Window(new TimerView(Model.Id))
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            Application.Current.OpenWindow(window);
        }


        public void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            AddOrUpdateCommand = new Command(ExecuteAddOrUpdate);   
            EditCommand = new Command(
                    (p) => ExecuteEdit((p as ProjectViewModel).Model.Id));
            DeleteCommand = new Command(ExecuteDelete);
            TimerCommand = new Command(ExecuteTimer);
            CloseCommand = new Command(ExecuteCloseProjects);


        }

        //--------------------------constructors
        public ProjectViewModel()
        {
            Model = new Project();
            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {

            Model = new Project { ClientId = clientId };
            SetupCommands();
        
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetupCommands();
        }

        public ProjectViewModel(int clientId, int projectId)
        {
            if (projectId > 0 )
            {
                Model = ProjectService.Current.Get(projectId);
            }
            else
            {
                Model = new Project { ClientId = clientId };
            }
            SetupCommands();
        }


        //-------------------------------------------------DELETE---------------------------------------------------

        public ICommand DeleteCommand { get; private set; }

        public void ExecuteDelete()
        {
            ProjectService.Current.Delete(Model.Id);
            

        }

        public void Delete()
        {
            ProjectService.Current.Delete(Model);
        }

        //-----------------------------------------------EDIT----------------------------------------------
        public ICommand EditCommand { get; private set; }

        public void Edit()
        {
            ProjectService.Current.Edit(Model);
        }





        public void ExecuteEdit(int id)
        {
            int clientId = Model.ClientId;
            Shell.Current.GoToAsync($"//ProjectDetail?projectId={id}&clientId={clientId}");

            
        }


        public ICommand AddOrUpdateCommand { get; private set; }

        private void ExecuteAddOrUpdate()
        {
            if (Model.Id == 0)
            {
                // Adding a new project
                Model.IsActive = true;
                ProjectService.Current.Add(Model);
                Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
            }
            else
            {
                // Editing an existing project
                ProjectService.Current.Edit(Model);
                Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
            }
        }


        //--------------------------------------------------ADD---------------------------------------------
        public void Add()
        {
            ProjectService.Current.Add(Model);
        }


        //-----------------------------------------Close project---------------------------------------------------

        public ICommand CloseCommand { get; private set; }

        public void ExecuteCloseProjects()
        {

            Model.IsActive = false;
            Model.ClosedDate = DateTime.Now;
            ProjectService.Current.Delete(Model);

            Application.Current.MainPage.DisplayAlert("Project Inactivated", "The project has been inactivated.", "OK");


        }









        ////////////////////////////////////////////////////////////////////////////////////////////////
        //                                            BILLS                                          ///
        ////////////////////////////////////////////////////////////////////////////////////////////////





        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>();
                }

                return new ObservableCollection<BillViewModel>(
                    BillService.Current.Bills
                        .Where(b => b.ProjectId == Model.Id)
                        .Select(bill => new BillViewModel(bill))
                );
            }
        }



        //public void RefreshProjects()
        //{
        //    NotifyPropertyChanged(nameof(Bills));
        //}

        public ICommand CreateBillCommand { get; private set; }

        private void ExecuteCreateBill()
        {
            
            Shell.Current.GoToAsync($"//BillDetail?projectId={Model.Id}");
        }


    }
}