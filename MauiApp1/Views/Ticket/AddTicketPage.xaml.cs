using ClassLibrary.Models;
using MauiApp2.ViewModels;
using TicketModel = ClassLibrary.Models.Ticket;

namespace MauiApp2.Views.Ticket;

public partial class AddTicketPage : ContentPage
{
	private TicketViewModel _ticketViewModel;
	private EmployeesViewModel _employeeViewModel;
	public AddTicketPage(TicketViewModel ticketViewModel, EmployeesViewModel employeesViewModel)
	{
		InitializeComponent();
		_ticketViewModel = ticketViewModel;
		_employeeViewModel = employeesViewModel;

		//extract and save statuses from ticket class
		StatusPicker.ItemsSource = Enum.GetValues(typeof(TicketModel.StatusEnum))
										.Cast<TicketModel.StatusEnum>()
										.ToList();

		//extract and save the existing in memory employees
		EmployeePicker.ItemsSource = _employeeViewModel.Employees;

		EmployeePicker.ItemDisplayBinding = new Binding("UserName");
	}

	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
		//no exception handling
		_ticketViewModel.NewTicketId = int.Parse(TicketIdInput.Text);
		_ticketViewModel.NewTitle = TitleInput.Text;
        _ticketViewModel.NewDescription = DescriptionInput.Text;

        //no exception handling
        _ticketViewModel.NewPriority = int.Parse(PriorityInput.Text);
		_ticketViewModel.NewIsResolved = IsActiveSwitch.IsToggled;
		
		if(EmployeePicker.SelectedItem != null)
		{
			_ticketViewModel.NewCreatedBy = (Employee)EmployeePicker.SelectedItem;
        }

		
		if(StatusPicker.SelectedItem != null)
		{
			_ticketViewModel.NewStatus = (TicketModel.StatusEnum)StatusPicker.SelectedItem;
        }

		_ticketViewModel.AddTicket();
        System.Diagnostics.Debug.WriteLine($"Current tickets count in add ticket method: {_ticketViewModel.Tickets.Count}");

        await DisplayAlert("Success", $"Ticket {_ticketViewModel.NewTitle} added!", "OK");
        await Navigation.PopAsync();
    }
}