using System;
using System.Collections.ObjectModel;
using Assignment1.Library.Services;
using Assignment1.Models;


namespace Assignment2.MAUI.ViewModels
{
    public class BillListViewModel
    {
        private int clientId;

        public Client Model { get; set; }

        public ObservableCollection<BillViewModel> Bills { get; set; }

        public BillListViewModel()
        {
            Bills = new ObservableCollection<BillViewModel>();
        }


        public BillListViewModel(Client client)
        {
            Model = client;
            int projectId = Model.ProjectId.Id;
            LoadBills();
        }

        public BillListViewModel(int clientId)
        {
            this.clientId = clientId;
        }

        private void LoadBills()
        {
            if (Model == null || Model.Id == 0)
            {
                Bills = new ObservableCollection<BillViewModel>();
            }
            else
            {
                var allProjects = ProjectService.Current.Projects
                    .Where(p => p.ClientId == Model.Id);

                var allBills = BillService.Current.Bills
                    .Where(b => allProjects.Any(p => p.Id == b.ProjectId))
                    .ToList();

                Bills = new ObservableCollection<BillViewModel>(
                    allBills.Select(bill => new BillViewModel(bill))
                );
            }


        }
    }
}

