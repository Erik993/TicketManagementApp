using ClassLibrary.Models;
using System.Collections.ObjectModel;

namespace MauiApp2.ViewModels
{
    public class EmployeesViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; } = new();

        public int NewUserId { get; set; }
        public string NewUserName { get; set; } = string.Empty;
        public string NewEmail { get; set; } = string.Empty;
        public bool NewIsActve { get; set; }


        //2 overloaded Add methods
        public void AddEmployee()
        {
            Employee empl = new(NewUserId, NewUserName, NewEmail, NewIsActve);
            Employees.Add(empl);
        }


        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }


        public void Reset()
        {
            Employees.Clear();
        }



    }
}
