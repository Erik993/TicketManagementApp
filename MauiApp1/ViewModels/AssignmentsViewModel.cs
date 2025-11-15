using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.ViewModels
{
    public class AssignmentsViewModel
    {
        public ObservableCollection<Assignment> Assignments { get; set; } = new();

        public ITSupport? NewITSupport { get; set; }
        public Ticket? NewTicket { get; set; }
        public string? NewComment { get; set; }

        public void AddAssignment()
        {
            Assignment assignment = new(NewITSupport, NewTicket, NewComment);
            Assignments.Add(assignment);
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
        }

        public void Reset()
        {
            Assignments.Clear();
        }


        // updated ticket is passed
        // looking for an assignemnt with the same Assigned_at date as in the passed (updated) ticket int the observable collection
        // there are no id for assignement...
        // then rewrite ticket in observalbe collection with the updated assignment data
        public void UpdateAssignment(Assignment updatedAssignment)
        {
            int index = -1;
            for (int i = 0; i <Assignments.Count; i++)
            {
                if (Assignments[i].AssignedAt == updatedAssignment.AssignedAt)
                {
                    index = i;
                    break;
                }
            }

            if(index >= 0)
            {
                Assignments[index] = updatedAssignment;
            }
        }
        

    }
}
