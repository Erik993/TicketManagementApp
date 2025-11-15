using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbtractClasses;

namespace ClassLibrary.Models;

public class Employee : User
{
    //Contract date cannot be changed after initialization
    public DateTime ContractDate { get; init; }

    //constructor has 1 optional argument - contract date, by default, if it is not provided it is null.
    //If null, then assign DateTime.Now date.
    public Employee(int id, string name, string email, bool isactive, DateTime? contractDate = null) : base(id, name, email, isactive)
    {
        ContractDate = contractDate ?? DateTime.Now;
    }

    public Employee() { }

    //
    public override string ToString()
    {
        return base.ToString() + $", Contract Date: {ContractDate}";
    }
}
