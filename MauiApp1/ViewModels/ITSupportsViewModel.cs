
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Models.ITSupport;
using ClassLibrary.Models;

namespace MauiApp2.ViewModels
{
    public class ITSupportsViewModel
    {

        public ObservableCollection<ITSupport> ITSupports { get; set; } = new();

        public int NewUserId { get; set; }
        public string NewUserName { get; set; } = string.Empty;
        public string NewEmail { get; set; } = string.Empty;
        public bool NewIsActve { get; set; }
        public Role NewSpecialization;


        //2 overloaded Add methods
        public void AddITSupport()
        {
            ITSupport itSup = new(NewUserId, NewUserName, NewEmail, NewIsActve, NewSpecialization);
            ITSupports.Add(itSup);
        }

        public void AddITSupport(ITSupport itSupport)
        {
            ITSupports.Add(itSupport);
        }


        public void Reset()
        {
            ITSupports.Clear();
        }
            
    }
}
