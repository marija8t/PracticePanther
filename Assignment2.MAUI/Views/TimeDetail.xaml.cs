using Assignment1.Library.Models;
using Assignment1.Library.Services;
using Assignment1.Models;
using Assignment2.MAUI.ViewModels;
using System.Linq;


namespace Assignment2.MAUI.Views;


public partial class TimeDetail : ContentPage
{
   
    public TimeDetail()
    {
        InitializeComponent();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Times");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        //if doesnt work try timeID
        BindingContext = new TimeViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Times");
    }







}
