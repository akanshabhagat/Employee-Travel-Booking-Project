using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a List of capital city names in Africa
        List<string> africanCapitalCities = new List<string>
        {
            "Cairo", "Nairobi", "Pretoria", "Addis Ababa", "Accra"
        };

        // Display all the capital cities
        Console.WriteLine("All African Capital Cities:");
        DisplayCapitalCities(africanCapitalCities);

        // Insert Ghana's capital city at element 3
        africanCapitalCities.Insert(2, "Accra");

        // Display the updated list
        Console.WriteLine("\nAfter Inserting Ghana's Capital City:");
        DisplayCapitalCities(africanCapitalCities);
    }

    static void DisplayCapitalCities(List<string> cities)
    {
        foreach (var city in cities)
        {
            Console.WriteLine(city);
        }
    }
}
