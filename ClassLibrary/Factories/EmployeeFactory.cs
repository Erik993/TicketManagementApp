using System;

using ClassLibrary.Models;

namespace ClassLibraryFactories;

public class EmployeeFactory
{
    public Employee CreateItem(int index)
    {
        var rand = new Random();
        int randNum = rand.Next(0, 1000);

        return new Employee(
            id: index,
            name: $"employee{randNum}",
            email: $"employee{randNum}@gmail.com",
            isactive: index % 2 == 0,
            contractDate: DateTime.Now
            );
    }

}
