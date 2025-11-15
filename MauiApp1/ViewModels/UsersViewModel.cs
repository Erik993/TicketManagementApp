using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.ViewModels
{
    //used to combine Employees and ITSupoorts and show them in 1 ShowUsersPage
    public class UsersViewModel
    {
        public EmployeesViewModel EmployeesVM { get; set; }
        public ITSupportsViewModel ITSupportsVM { get; set; }

        public UsersViewModel(EmployeesViewModel emloyeesVM, ITSupportsViewModel itSupportVM)
        {
            EmployeesVM = emloyeesVM;
            ITSupportsVM = itSupportVM;
        }
    }
}
