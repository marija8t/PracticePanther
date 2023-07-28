using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Assignment1.Library.Services;
using Assignment1.Models;


namespace Assignment2.MAUI.ViewModels
{
	public class ClientViewViewModel : INotifyPropertyChanged
    {
        private Client SelectedClient { get; set; }
 

  

        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return
                    new ObservableCollection<ClientViewModel>
                    (ClientService
                        .Current.Clients.Where(c => c.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty))
                        .Select(c => new ClientViewModel(c)).ToList());
            }
 
        }

        
        public ClientViewViewModel()
        {
            SelectedClient = new Client();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


//------------------------------------DELETE------------------------------------------------------
        public void Delete()
        {
            if (SelectedClient != null)
            {
                ClientService.Current.Delete(SelectedClient.Id);
                SelectedClient = null;
                NotifyPropertyChanged(nameof(Clients));
                NotifyPropertyChanged(nameof(SelectedClient));
            }
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

//------------------------------------SEARCH------------------------------------------------------
        public string Query { get; set; }


        public void Search()
        {
            NotifyPropertyChanged(nameof(Clients));

        }


//------------------------------------EDIT------------------------------------------------------



        public void Edit()
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={SelectedClient?.Id ?? 0}");
        }
//------------------------------------CLOSE CLIENT------------------------------------------------------


    }
}

