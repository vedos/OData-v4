using ODataService.Helper;
using ODataService.Models;
using ODataService.Services;
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to OData V4 service: ");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. List all people");
            Console.WriteLine("2. Search for somebody");

            string s = Console.ReadLine();
            Console.WriteLine(new TripPinRESTierService().getPeople().value.toString<People>());
        }
    }
}
