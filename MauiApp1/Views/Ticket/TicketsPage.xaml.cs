using ClassLibraryFactories;
using MauiApp2.ViewModels;
using Services;
using System.Security.Cryptography;
using TicketModel = ClassLibrary.Models.Ticket;

namespace MauiApp2.Views.Ticket;

public partial class TicketsPage : ContentPage
{
	private TicketViewModel _ticketViewModel;
	private EmployeesViewModel _employeeViewModel;
	private JsonFileManager _jsonFileManager = new();
	private TicketFactory _ticketFactory;

	//ticket factory should has access to the employeeViewModel to readl the observable collection
	//private TicketFactory _ticketFactory = new(_employeeViewModel);
	public TicketsPage(TicketViewModel ticketViewModel, EmployeesViewModel employeeViewModel)
	{
		InitializeComponent();
		_ticketViewModel = ticketViewModel;
		_employeeViewModel = employeeViewModel;

		//ticket factory takes Employees, employees is observable collection and implements IEnumerable interface
		_ticketFactory = new TicketFactory(_employeeViewModel.Employees);
	}

	private async void ShowTicketsButtonClicked(object sender, EventArgs e)
	{
		System.Diagnostics.Debug.WriteLine($"Current tickets count in ticket page: {_ticketViewModel.Tickets.Count}");
        await Navigation.PushAsync(new ShowTicketsPage(_ticketViewModel, _employeeViewModel));
	}

	private async void AddTicketButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddTicketPage(_ticketViewModel, _employeeViewModel));
	}

	public void SaveTicketsToJsonClicked(object sender, EventArgs e)
	{
		_jsonFileManager.Save(_ticketViewModel.Tickets.ToList());
        DisplayAlert("Success", "Tickets are saved to JSON file.", "OK");
    }

	public void LoadTicketsFromJsonClicked(object sender, EventArgs e)
	{
		var loaded = _jsonFileManager.Load<TicketModel>();
		foreach (var item in loaded)
		{
			_ticketViewModel.AddTicket(item);
		}
        DisplayAlert("Success", "ItSupports loaded from JSON file.", "OK");
    }

	public void CreateTestTicketClicked(object sender, EventArgs e)
	{
		var ticket = _ticketFactory.CreateItem(1);
		_ticketViewModel.AddTicket(ticket);
        DisplayAlert("Success", "Test Ticket is created", "OK");
    }

	public void DeleteTicketsClicked(object sender, EventArgs e)
	{
		_ticketViewModel.Reset();
        DisplayAlert("Success", "Tickets are deleted from memory", "OK");
    }

}