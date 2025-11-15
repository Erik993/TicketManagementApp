using ClassLibrary.Models;
using MauiApp2.ViewModels;

using TicketModel = ClassLibrary.Models.Ticket;
using ITSupportModel = ClassLibrary.Models.ITSupport;

namespace MauiApp2.Views.Assignments;

public partial class UpdateAssignmentPage : ContentPage
{
	private Assignment _assignment;
	private AssignmentsViewModel _assignmentsViewModel;
	private TicketViewModel _ticketViewModel;
	private ITSupportsViewModel _itSupportViewModel;
	public UpdateAssignmentPage(Assignment assignment, AssignmentsViewModel assignmentsViewModel, TicketViewModel ticketViewModel, ITSupportsViewModel itSupportViewModel)
	{
		InitializeComponent();

		_assignment = assignment;
		_assignmentsViewModel = assignmentsViewModel;
		_ticketViewModel = ticketViewModel;
		_itSupportViewModel = itSupportViewModel;

		TicketPicker.ItemsSource = _ticketViewModel.Tickets;
		ITSupportPicker.ItemsSource = _itSupportViewModel.ITSupports;

        // Prefill fields with old data
        CommentInput.Text = _assignment.Comment;
		TicketPicker.SelectedItem = _assignment.Ticket;
		ITSupportPicker.SelectedItem = _assignment.Support;

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
	{
		_assignment.Comment = CommentInput.Text;
		_assignment.Ticket = (TicketModel)TicketPicker.SelectedItem;
		_assignment.Support = (ITSupportModel)ITSupportPicker.SelectedItem;

		_assignmentsViewModel.UpdateAssignment(_assignment);

        await DisplayAlert("Success", $"Assignment is updated!", "OK");
        await Navigation.PopAsync();
    }
}