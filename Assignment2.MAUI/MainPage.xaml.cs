using Assignment1.Library.Models;
using Assignment2.MAUI.ViewModels;

namespace Assignment2.MAUI;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();	

	}


    private void ClientsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    void EmployeeClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//Employees");
    }

    void TimeClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//Times");
    }
}


