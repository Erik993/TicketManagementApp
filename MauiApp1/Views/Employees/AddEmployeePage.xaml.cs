using MauiApp2.ViewModels;

namespace MauiApp2.Views.Employees;

public partial class AddEmployeePage : ContentPage
{
    private EmployeesViewModel _viewModel;
    public AddEmployeePage(EmployeesViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
    }

	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
        //no exception handling
        _viewModel.NewUserId = int.Parse(IdInput.Text);
        _viewModel.NewUserName = NameInput.Text;
        _viewModel.NewEmail = EmailInput.Text;
        _viewModel.NewIsActve = IsActiveSwitch.IsToggled;

        _viewModel.AddEmployee();

        await DisplayAlert("Success", $"Employee {_viewModel.NewUserName} added!", "OK");
        await Navigation.PopAsync();
    }

}