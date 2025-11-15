using System;
using System.Linq;
using ClassLibrary.Models;

namespace ClassLibraryFactories;

public class AssignmentFactory
{
    //private ITSupportRepository _itSupportRepo;
    //private TicketRepository _ticketRepo;

    private IEnumerable<Ticket> _tickets;
    private IEnumerable<ITSupport> _itSupports;
    

    private Random _rand = new Random();

    
    public AssignmentFactory(IEnumerable<Ticket> tickets, IEnumerable<ITSupport> itSupports)
    {
        _tickets = tickets;
        _itSupports = itSupports;
    }


    public Assignment CreateItem()
    {
        //var allItSupports = _itSupportRepo.GetAll(); // save all the elements
        // var allTickets = _ticketRepo.GetAll(); // save all the elements

        var itSupportsList = _itSupports.ToList();
        var ticketsList = _tickets.ToList();

        ITSupport? itSupport = null;
        Ticket? ticket = null;

        if (itSupportsList.Count > 0)
        {
            //save random element from sequence
            itSupport = itSupportsList.ElementAt(_rand.Next(0, itSupportsList.Count()));
        }

        if (ticketsList.Count > 0)
        {
            //save random element from sequence
            ticket = ticketsList.ElementAt(_rand.Next(0, ticketsList.Count()));
        }

        return new Assignment(
            // if itsupport is null, then new support with default data is created
            support: itSupport ?? new ITSupport(0, "default Support", "defSup@gmail.com", true, ITSupport.Role.HelpDesk),

            // if ticket is null, then new ticket with default data is created with created by as null
            ticket: ticket ?? new Ticket("default Title", "default description", 1, 0, null, Ticket.StatusEnum.Open, false),
            comment: "default comment"
        );
    }
}