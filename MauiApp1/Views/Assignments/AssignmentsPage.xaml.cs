using ClassLibraryFactories;
using MauiApp2.ViewModels;
using Services;
using System.Diagnostics.CodeAnalysis;
using AssignmentModel = ClassLibrary.Models.Assignment;

namespace MauiApp2.Views.Assignments;

public partial class AssignmentsPage : ContentPage
{
	private AssignmentsViewModel _assignmentsViewModel;
	private TicketViewModel _ticketViewModel;
	private ITSupportsViewModel _itSupportsViewModel;
	private JsonFileManager _jsonFileManager = new();
	private AssignmentFactory _assignmentFactory;

	public AssignmentsPage(AssignmentsViewModel assignmentsViewModel, TicketViewModel ticketViewModel, ITSupportsViewModel itSupportsViewModel)
	{
		InitializeComponent();
		_assignmentsViewModel = assignmentsViewModel;
		_ticketViewModel = ticketViewModel;
		_itSupportsViewModel = itSupportsViewModel;

		_assignmentFactory = new AssignmentFactory(_ticketViewModel.Tickets, _itSupportsViewModel.ITSupports);
	}


	private async void ShowAssignmentsButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ShowAssignmentsPage(_assignmentsViewModel, _ticketViewModel, _itSupportsViewModel));
	}

	private async void AddAssignmentButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddAssignmentPage(_assignmentsViewModel, _ticketViewModel, _itSupportsViewModel));
	}

	private void SaveAssignmentsToJsonClicked(object sender, EventArgs e)
	{
		_jsonFileManager.Save(_assignmentsViewModel.Assignments.ToList());
        DisplayAlert("Success", "Assignments are saved to JSON file.", "OK");
    }

	private void LoadAssignmentsFromJsonClicked(object sender, EventArgs e)
	{
		var loaded = _jsonFileManager.Load<AssignmentModel>();
		foreach(var item in loaded)
		{
			_assignmentsViewModel.AddAssignment(item);
		}

        DisplayAlert("Success", "ItSupports loaded from JSON file.", "OK");
    }

	private void DeleteAssignmentsClicked(object sender, EventArgs e)
	{
		_assignmentsViewModel.Reset();
        DisplayAlert("Success", "Assignments are deleted from memory", "OK");
    }

	public void CreateTestAssignmentClicked(object sender, EventArgs e)
	{
		var assignment = _assignmentFactory.CreateItem();
		_assignmentsViewModel.AddAssignment(assignment);
        DisplayAlert("Success", "Test Assignment is created", "OK");

    }



}