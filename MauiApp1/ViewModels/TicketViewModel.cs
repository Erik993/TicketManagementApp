using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Models.Ticket;


namespace MauiApp2.ViewModels
{
    public class TicketViewModel
    {
        public ObservableCollection<Ticket> Tickets { get; set; } = new();

        public int NewTicketId { get; set; }
        public string NewTitle { get; set; } = string.Empty;
        public string NewDescription { get; set; } = string.Empty;
        public int NewPriority { get; set; }
        public Employee? NewCreatedBy { get; set; }

        public Ticket.StatusEnum NewStatus;
        public bool NewIsResolved;

        public void AddTicket()
        {
            Ticket ticket = new(NewTitle, NewDescription, NewPriority, 
                NewTicketId, NewCreatedBy, NewStatus, NewIsResolved);

            Tickets.Add(ticket);
        }

        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }


        public void Reset()
        {
            Tickets.Clear();
        }

        // updated ticket is passed
        // looking for a ticket with the same id as in the passed (updated) ticket int the observable collection
        // then rewrite ticket in observalbe collection with the updated ticket data
        public void UpdateTicket(Ticket updatedTicket)
        {
            int index = -1;
            for(int i = 0; i < Tickets.Count; i++)
            {
                if (Tickets[i].TicketID == updatedTicket.TicketID)
                {
                    index = i;
                    break;
                }
            }

            if(index >= 0)
            {
                Tickets[index] = updatedTicket;
            }
        }
        
    }
}
