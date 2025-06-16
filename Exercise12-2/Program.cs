using System;
using System.Linq;
using Exercise02.Models;

namespace Exercise02
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var db = new Northwind())
      {
        // Get all unique cities
        var cities = db.Customers
                       .Where(c => c.City != null)
                       .Select(c => c.City)
                       .Distinct()
                       .OrderBy(c => c)
                       .ToList();

        Console.WriteLine("Available cities:");
        Console.WriteLine(string.Join(", ", cities));
        Console.WriteLine();

        Console.Write("Enter the name of a city: ");
        string inputCity = Console.ReadLine();

        var customersInCity = db.Customers
                                .Where(c => c.City == inputCity)
                                .Select(c => c.CompanyName)
                                .ToList();

        if (customersInCity.Any())
        {
          Console.WriteLine($"\nThere are {customersInCity.Count} customer(s) in {inputCity}:");
          foreach (var name in customersInCity)
            Console.WriteLine(name);
        }
        else
        {
          Console.WriteLine($"\nNo customers found in {inputCity}.");
        }
      }
    }
  }
}
