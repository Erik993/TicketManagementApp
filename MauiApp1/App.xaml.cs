using ClassLibrary.Models;
using MauiApp2.ViewModels;
using Services;

namespace MauiApp2
{
    public partial class App : Application
    {
        //Employee, IT Support, Ticket, Assignment viewmodels with observable collection are created 1 time, there
        public EmployeesViewModel EmployeesVM { get; } = new();
        public ITSupportsViewModel ITSupportVM { get; } = new();
        public TicketViewModel TicketVM { get; } = new();
        public AssignmentsViewModel AssignmentVM { get; } = new();
        public JsonFileManager JsonManager { get; } = new();
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            //This is required for PushAsync to work
            MainPage = new NavigationPage(new MainPage(EmployeesVM, ITSupportVM, TicketVM, AssignmentVM, JsonManager));
        }
    }
}
