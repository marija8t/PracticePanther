using Assignment1.Library.Services;
using System.Collections.ObjectModel;
using Assignment1.Models;
using Assignment2.MAUI.ViewModels;
using System.Diagnostics;

namespace Assignment2.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class BillList : ContentPage
{
    public int ClientId { get; set; }

    public BillList()
	{
		InitializeComponent();
        BindingContext = new BillListViewModel();
    }

    void GoBackClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync($"//ClientDetail?clientId={ClientId}");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new BillListViewModel(ClientId);
     
    }
}
