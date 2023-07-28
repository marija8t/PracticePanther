using Assignment1.Models;
using Assignment2.MAUI.ViewModels;

namespace Assignment2.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class EmployeeDetail : ContentPage
{
    public int EmployeeId { get; set; }

    public EmployeeDetail()
	{
		InitializeComponent();
	}

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Employees");
    }


    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employees");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewModel(EmployeeId);
    }
}
