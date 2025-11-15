using MauiApp2.ViewModels;


namespace MauiApp2.Views.Users;

public partial class ShowUsersPage : ContentPage
{
	private EmployeesViewModel _employeeViewModel;
	private ITSupportsViewModel _itSupportViewModel;

	public ShowUsersPage(EmployeesViewModel employeesViewModel, ITSupportsViewModel itSupportsViewModel)
	{
		InitializeComponent();
		_employeeViewModel = employeesViewModel;
		_itSupportViewModel = itSupportsViewModel;
		BindingContext = new UsersViewModel(_employeeViewModel, _itSupportViewModel);

    }
}