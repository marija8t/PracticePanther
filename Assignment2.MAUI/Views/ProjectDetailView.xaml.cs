using Assignment1.Library.Models;
using Assignment1.Library.Services;
using Assignment1.Models;
using Assignment2.MAUI.ViewModels;




namespace Assignment2.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }

    public int ProjectId { get; set; }

    //private string? shortname { get; set; }

    public ProjectDetailView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewModel();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {

        //BindingContext = new ProjectViewModel(ClientId);
       
   
        BindingContext = new ProjectViewModel(ClientId, ProjectId);
        //(BindingContext as TimeViewViewModel).RefreshTimes();

    }


    void CancelClicked(System.Object sender, System.EventArgs e)
    {
        //Shell.Current.GoToAsync("//ClientDetail");
        //Shell.Current.GoToAsync($"//ClientDetail?clientId={ClientId}");
        Shell.Current.GoToAsync($"//ClientDetail?projectId={ProjectId}&clientId={ClientId}");
    }

    private void AcceptEditClicked(object sender, EventArgs e)
    {

        (BindingContext as ProjectViewModel).Edit();
        Shell.Current.GoToAsync($"//ClientDetail?clientId={ClientId}");
    }

    void BillClicked(System.Object sender, System.EventArgs e)
    {
        //Shell.Current.GoToAsync("//BillDetail");

        // Get the selected project ID
        int projectId = (BindingContext as ProjectViewModel).Model.Id;


        //// Pass the filtered time entries to the BillDetail view
        Shell.Current.GoToAsync($"//BillDetail?projectId={projectId}");
    }




}
