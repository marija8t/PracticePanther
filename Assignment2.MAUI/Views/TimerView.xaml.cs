using Assignment1.Models;
using Assignment2.MAUI.ViewModels;

namespace Assignment2.MAUI.Views;

public partial class TimerView : ContentPage
{
	public TimerView(int projectId)
	{
		InitializeComponent();
        BindingContext = new TimerViewModel(projectId);
    }
}
