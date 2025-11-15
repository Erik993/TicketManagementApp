using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models;

public class Ticket
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Priority { get; set; } = 1; // some default value
    public int TicketID { get; set; }

    public Employee CreatedBy { get; set; }

    public enum StatusEnum
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }

    public StatusEnum Status { get; set; }

    public bool IsResolved { get; set; }

    // so far Ticket id is expected as argument, there should be automatic id counter
    // to-do: check if object is null???
    public Ticket(string title, string description, int priority, int ticketId, Employee createdBy, StatusEnum status, bool isResolved)
    {
        Title = title;
        Description = description;
        Priority = priority;
        TicketID = ticketId;
        CreatedBy = createdBy;
        Status = status;
        IsResolved = isResolved;
    }

    // Created by: {CreatedBy} returns all the info about creator (all fields) from Employee class
    public override string ToString()
    {
        return $"Title: {Title}, Description: {Description}, Priority: {Priority}, " +
            $"TicketID: {TicketID}, \nCreated by: {CreatedBy}\n, Status: {Status}, Is resolved: {IsResolved}";
    }
}

