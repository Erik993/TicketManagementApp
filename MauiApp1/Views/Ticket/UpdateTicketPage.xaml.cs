using MauiApp2.ViewModels;
using ClassLibrary.Models;

using TicketModel = ClassLibrary.Models.Ticket;

namespace MauiApp2.Views.Ticket;

public partial class UpdateTicketPage : ContentPage
{
    // to save the ticket for update
    private TicketModel _ticket;
    private TicketViewModel _ticketViewModel;
    private EmployeesViewModel _employeeViewModel;

    public UpdateTicketPage(TicketModel ticket, TicketViewModel ticketViewModel, EmployeesViewModel employeeViewModel)
	{
		InitializeComponent();

        _ticket = ticket;
        _ticketViewModel = ticketViewModel;
        _employeeViewModel = employeeViewModel;

        StatusPicker.ItemsSource = Enum.GetValues(typeof(TicketModel.StatusEnum)).Cast<TicketModel.StatusEnum>().ToList();
        EmployeePicker.ItemsSource = _employeeViewModel.Employees;
        //EmployeePicker.ItemDisplayBinding = new Binding("UserName");

        // Prefill fields with old data
        //TicketIdInput.Text = _ticket.TicketID.ToString();
        TitleInput.Text = _ticket.Title;
        DescriptionInput.Text = _ticket.Description;
        PriorityInput.Text = _ticket.Priority.ToString();
        StatusPicker.SelectedItem = _ticket.Status;

        EmployeePicker.SelectedItem = _ticket.CreatedBy; // or Employee object
        IsActiveSwitch.IsToggled = _ticket.IsResolved;
        
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Update ticket with modified values
        //_ticket.TicketID = int.Parse(TicketIdInput.Text);
        _ticket.Title = TitleInput.Text;
        _ticket.Description = DescriptionInput.Text;
        _ticket.Priority = int.Parse(PriorityInput.Text);
        _ticket.Status = (TicketModel.StatusEnum)StatusPicker.SelectedItem;
        _ticket.CreatedBy = (Employee)EmployeePicker.SelectedItem;
        _ticket.IsResolved = IsActiveSwitch.IsToggled;

        // Optionally refresh the collection in TicketViewModel
        _ticketViewModel.UpdateTicket(_ticket);

        await DisplayAlert("Success", $"Ticket {_ticket.TicketID} updated!", "OK");
        await Navigation.PopAsync();
    }
}