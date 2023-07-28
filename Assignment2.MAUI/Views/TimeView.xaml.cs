﻿using Assignment1.Library.Services;
using Assignment1.Models;
using Assignment2.MAUI.ViewModels;

namespace Assignment2.MAUI.Views;


public partial class TimeView : ContentPage
{
 

    public TimeView()
	{
		InitializeComponent();
        BindingContext = new TimeViewViewModel();
        
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        
        (BindingContext as TimeViewViewModel).RefreshTimes();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeDetail");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {

        (BindingContext as TimeViewViewModel).RefreshTimes();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewViewModel).RefreshTimes();
    }
}
