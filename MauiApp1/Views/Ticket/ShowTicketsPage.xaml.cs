using MauiApp2.ViewModels;
using ClassLibrary.Models;
using TicketModel = ClassLibrary.Models.Ticket;

namespace MauiApp2.Views.Ticket;

public partial class ShowTicketsPage : ContentPage
{
	private TicketViewModel _ticketViewModel;
	private EmployeesViewModel _employeeViewModel;
	public ShowTicketsPage(TicketViewModel ticketViewModel, EmployeesViewModel employeesViewModel)
	{
		InitializeComponent();
		_ticketViewModel = ticketViewModel;
		_employeeViewModel = employeesViewModel;
		BindingContext = _ticketViewModel;
	}

    //funkcija no AI r?ka
    private async void OnTicketSelected(object sender, SelectionChangedEventArgs e)
	{
		var selectedTicket = e.CurrentSelection.FirstOrDefault() as TicketModel;
		if (selectedTicket == null) return;

        // Clear selection so user can select it again
        ((CollectionView)sender).SelectedItem = null;

        await Navigation.PushAsync(new UpdateTicketPage(selectedTicket, _ticketViewModel, _employeeViewModel));
    }


}