using MauiApp2.ViewModels;
using ClassLibrary.Models;

namespace MauiApp2.Views.Assignments;

public partial class ShowAssignmentsPage : ContentPage
{
    private AssignmentsViewModel _assignmentsViewModel;
    private TicketViewModel _ticketViewModel;
    private ITSupportsViewModel _itSupportsViewModel;
    public ShowAssignmentsPage(AssignmentsViewModel assignmentsViewModel, TicketViewModel ticketViewModel, ITSupportsViewModel itSupportsViewModel)
	{
		InitializeComponent();
        _assignmentsViewModel = assignmentsViewModel;
        _ticketViewModel = ticketViewModel;
        _itSupportsViewModel = itSupportsViewModel;
        BindingContext = _assignmentsViewModel;
    }

    //funkcija no AI rīka
    public async void OnAssignmentSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedAssignment = e.CurrentSelection.FirstOrDefault() as Assignment;
        if (selectedAssignment == null) return;

        // Clear selection so user can select it again
        ((CollectionView)sender).SelectedItem = null;

        await Navigation.PushAsync(new UpdateAssignmentPage(selectedAssignment, _assignmentsViewModel, _ticketViewModel, _itSupportsViewModel));
    }

    //TODO - make clickable to update
}