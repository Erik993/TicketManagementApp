using MauiApp2.ViewModels;

namespace MauiApp2.Views.Employees;

public partial class ShowEmployeesPage : ContentPage
{
    private EmployeesViewModel _viewModel;
    public ShowEmployeesPage(EmployeesViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;

        //BindingContext is only set when the constructor runs
        BindingContext = _viewModel;
    }
}