using MauiApp2.ViewModels;
using TicketModel = ClassLibrary.Models.Ticket;
using ITSupportModel = ClassLibrary.Models.ITSupport;

namespace MauiApp2.Views.Assignments;

public partial class AddAssignmentPage : ContentPage
{
    private AssignmentsViewModel _assignmentsViewModel;
    private TicketViewModel _ticketViewModel;
    private ITSupportsViewModel _itSupportsViewModel;

    public AddAssignmentPage(AssignmentsViewModel assignmentsViewModel, TicketViewModel ticketViewModel, ITSupportsViewModel itSupportsViewModel)
	{
		InitializeComponent();
        _assignmentsViewModel = assignmentsViewModel;
        _ticketViewModel = ticketViewModel;
        _itSupportsViewModel = itSupportsViewModel;

        TicketPicker.ItemsSource = _ticketViewModel.Tickets;
        ITSupportPicker.ItemsSource = _itSupportsViewModel.ITSupports;

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        _assignmentsViewModel.NewComment = CommentInput.Text;

        if(TicketPicker.SelectedItem != null)
        {
            _assignmentsViewModel.NewTicket = (TicketModel)TicketPicker.SelectedItem;
        }

        if (ITSupportPicker.SelectedItem != null)
        {
            _assignmentsViewModel.NewITSupport = (ITSupportModel)ITSupportPicker.SelectedItem;
        }

        _assignmentsViewModel.AddAssignment();
        await DisplayAlert("Success", $"Assignment was added!", "OK");
        await Navigation.PopAsync();
    }
}