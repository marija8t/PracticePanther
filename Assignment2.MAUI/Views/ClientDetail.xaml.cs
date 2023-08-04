using Assignment2.MAUI.ViewModels;
using Assignment1.Library.Models;
using Assignment1.Library.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assignment1.Models;

namespace Assignment2.MAUI.Views;


[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetail : ContentPage
{
    public int ClientId { get; set; }

    public ClientDetail()
	{
        InitializeComponent();
        BindingContext = new ClientViewModel();

    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Clients");
    }


    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        //(BindingContext as ProjectViewViewModel).RefreshProjectList();

        (BindingContext as ClientViewModel).RefreshProjects();
    }



    void CancelProjectClicked(Object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).RefreshProjects();
    }

    void CreateBillClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//BillDetail");


    }


    void BillListClicked(System.Object sender, System.EventArgs e)
    {
        //Shell.Current.GoToAsync("//BillList");
        //////
        int clientId = (BindingContext as ClientViewModel).Model.Id;
        //int projectId = (BindingContext as ClientViewModel).Model.ProjectId.Id;

        Shell.Current.GoToAsync($"//BillList?clientId={clientId}");
   

    }
}
