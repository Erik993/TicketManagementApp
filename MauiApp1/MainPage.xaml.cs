using MauiApp2.Views;
using MauiApp2.ViewModels;
using MauiApp2.Views.ITSupport;
using Services;
using ClassLibrary.Models;
using MauiApp2.Views.Ticket;
using System.Diagnostics;
using MauiApp2.Views.Users;
using MauiApp2.Views.Assignments;

namespace MauiApp2

    /*
     The program somethimes started to crash with exception, after a added UsersShow functionality to observe all the users in 1 page
     
     */
{
    public partial class MainPage : ContentPage
    {
        private EmployeesViewModel _employeesViewModel;
        private ITSupportsViewModel _itSupportsViewModel;
        private TicketViewModel _ticketsViewModel;
        private AssignmentsViewModel _assignmentViewModel;
        private JsonFileManager _jsonFileManager;
       
        public MainPage(EmployeesViewModel employeesViewModel, ITSupportsViewModel itSupportsViewModel, 
            TicketViewModel ticketViewModel, AssignmentsViewModel assignmentsViewModel, JsonFileManager jsonFileManager)
        {
            InitializeComponent();
            _employeesViewModel = employeesViewModel;
            _itSupportsViewModel = itSupportsViewModel;
            _ticketsViewModel = ticketViewModel;
            _jsonFileManager = jsonFileManager;
            _assignmentViewModel = assignmentsViewModel;
        }
        

        //redirecting to Employee Page
        private async void EmployeeButtonClicked(object sender, EventArgs e)
        {
            //PushAsync - pushes a new page onto the navigation stack
            // meaning it navigates to a new page with a back button to return. 
            await Navigation.PushAsync(new EmployeesPage(_employeesViewModel));
        }


        //redirecting to ITSupport Page
        private async void ITSupportButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ITSupportsPage(_itSupportsViewModel));
        }

        private async void TicketButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketsPage(_ticketsViewModel, _employeesViewModel));
        }

        private async void AllUserButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowUsersPage(_employeesViewModel, _itSupportsViewModel));
        }

        private async void AssignmentButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssignmentsPage(_assignmentViewModel, _ticketsViewModel, _itSupportsViewModel));
        }

        /*
        private void SaveAllDataToJsonClicked(object sender, EventArgs e)
        {
            //before saving the collection, need to cast it to List, beacause the jsonFileManager works with List
            _jsonFileManager.Save(_employeesViewModel.Employees.ToList());
            _jsonFileManager.Save(_itSupportsViewModel.ITSupports.ToList());
            DisplayAlert("Success", "Employees amd Supports saved to JSON file.", "OK");
        }

        //loading objects. Can load duplicates
        private void LoadAllDataFromJsonClicked(object sender, EventArgs e)
        {
            var loadedEmpls = _jsonFileManager.Load<Employee>();
            foreach(var element in loadedEmpls)
            {
                _employeesViewModel.AddEmployee(element);
            }

            var loadedItSups = _jsonFileManager.Load<ITSupport>();
            foreach(var element in loadedItSups)
            {
                _itSupportsViewModel.AddITSupport(element);
            }

            DisplayAlert("Success", "Employees loaded from JSON file.", "OK");
        }*/

    }
}
