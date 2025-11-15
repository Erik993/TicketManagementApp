using System;

using ClassLibrary.Models;

namespace ClassLibraryFactories;

public class EmployeeFactory
{
    public Employee CreateItem()
    {
        var rand = new Random();
        int randNum = rand.Next(0, 1000);

        return new Employee(
            //id: index,
            name: $"employee{randNum}",
            email: $"employee{randNum}@gmail.com",
            isactive: true,
            contractDate: DateTime.Now
            );
    }

}
