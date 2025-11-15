using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models;

public class Assignment
{
    //Assigned At, Support, Ticket is not changable
    public DateTime AssignedAt { get; init; }
    public ITSupport Support { get; set; }
    public Ticket Ticket { get; set; }
    public string Comment { get; set; } = string.Empty;

    // to-do: check if objects are null
    // comment is optional, can be an empty string
    public Assignment(ITSupport support, Ticket ticket, string comment = "")
    {
        AssignedAt = DateTime.Now;
        Support = support;
        Ticket = ticket;
        Comment = comment;
    }

    //Support: {Support}, Ticket: {Ticket} return all the info from their classes
    public override string ToString()
    {
        return $"Assigned at: {AssignedAt}, Support: {Support}, Ticket: {Ticket}, Comment: {Comment}";
    }

}

