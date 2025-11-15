using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClassLibrary.Models;

namespace ClassLibraryFactories;

public class TicketFactory
{
    //private List<Employee> _employees;
    //private EmployeeRepository _employeeRepo;

    private IEnumerable<Employee> _employees;
    private Random _rand = new Random();


    //public TicketFactory(List<Employee> employees)
    public TicketFactory(IEnumerable<Employee> employees)
    {
        _employees = employees;
    }


    public Ticket CreateItem(int index)
    {
        //create random integer to assign it in object
        //var employees = _employeeRepo.GetAll();
        var employeeList = _employees.ToList();
        int randNum = _rand.Next(0, 100);

        Employee? createdBy = null;
        if (employeeList.Count > 0)
        {
            int randIndex = _rand.Next(0, employeeList.Count);
            createdBy = employeeList[randIndex];
        }

        return new Ticket(
                title: $"title{randNum}",
                description: $"description{randNum}",
                priority: randNum,
                ticketId: index,
                createdBy: createdBy ?? new Employee(0, "DefaultCreator", "default@gmail.com", true, DateTime.Now),
                status: Ticket.StatusEnum.Open,
                isResolved: false
            );
    }
        
}
