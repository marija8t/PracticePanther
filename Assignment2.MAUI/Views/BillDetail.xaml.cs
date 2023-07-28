using System.Collections.ObjectModel;
using Assignment1.Library.Services;
using Assignment1.Models;
using Assignment2.MAUI.ViewModels;

namespace Assignment2.MAUI.Views;


[QueryProperty(nameof(ProjectId), "projectId")]
[QueryProperty(nameof(ClientId), "clientId")]
public partial class BillDetail : ContentPage
{
    public int ProjectId { get; set; }
    public int ClientId { get; set; }

    public BillDetail()
	{
		InitializeComponent();
        BindingContext = new BillViewModel();
    }

    void GoBackClicked(System.Object sender, System.EventArgs e)
    {

        Shell.Current.GoToAsync($"//ClientDetail?clientId={ClientId}");

    }


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new BillViewModel(ProjectId);
        //(BindingContext as BillViewModel).RefreshBills();
        
    }

 
}
