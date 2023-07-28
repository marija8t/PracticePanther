using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
//using Android.Telecom;
using Assignment1.Library.Services;
using Assignment1.Models;
using Assignment2.MAUI.Views;
//using static Android.App.DownloadManager;
//using static Android.Provider.Contacts;

namespace Assignment2.MAUI.ViewModels
{
	public class ClientDetailViewModel : INotifyPropertyChanged
    {

        //public string Name { get; set; }
        //public int Id { get; set; }

        //public ClientDetailViewModel(int id = 0)
        //{
        //    if (id > 0)
        //    {
        //        LoadById(id);
        //    }
        //}

        //public void LoadById(int id)
        //{
        //    if (id == 0) { return; }
        //    var person = ClientService.Current.GetById(id) as Client;
        //    if (person != null)
        //    {
        //        Name = person.Name;
        //        Id = person.Id;
        //    }

        //    NotifyPropertyChanged(nameof(Name));
            
        //}


        //public void AddClient()
        //{

        //    if (Id <= 0)
        //    {
        //        ClientService.Current.Add(new Client { Name = Name });
        //    }
        //    else
        //    {
        //        var refToUpdate = ClientService.Current.GetById(Id) as Client;
        //        refToUpdate.Name = Name;
        //    }
            
        //    Shell.Current.GoToAsync("//Clients");
         
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

