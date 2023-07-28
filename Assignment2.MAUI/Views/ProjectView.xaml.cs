using Assignment1.Models;
using Assignment2.MAUI.ViewModels;

namespace Assignment2.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectView()
	{
		InitializeComponent();
	}

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewViewModel(ClientId);
    }
}
