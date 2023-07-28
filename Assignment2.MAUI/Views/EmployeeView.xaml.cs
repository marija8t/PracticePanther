using Assignment2.MAUI.ViewModels;
using Assignment1.Library.Models;
using Assignment1.Library.Services;

namespace Assignment2.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();
        BindingContext = new EmployeeViewViewModel();
    }

    void GoBackClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    void SearchClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).Search();
    }

    void DeleteClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    void EditClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    void AddClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeDetail");
    }
}
