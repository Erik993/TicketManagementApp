using System;
using ClassLibrary.Models;

namespace ClassLibraryFactories;

public class ITSupportFactory
{
    public ITSupport CreateItem(int index)
    {
        var rand = new Random();

        int randId = rand.Next(0, 100);
        int randInt = rand.Next(1, 5);
        ITSupport.Role role = (ITSupport.Role)randInt; // get random role from enums

        return new ITSupport(
            id: index,
            name: $"itSupport{randId}",
            email: $"itSupport{randId}@gmail.com",
            isactive: index % 2 == 0,
            spec: role
        );
    }
}
