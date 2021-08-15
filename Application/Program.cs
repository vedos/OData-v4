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
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.UnhandledExceptionTrapper;

            TripPinRESTierService tripPinRESTierService = new TripPinRESTierService();
            string enter;
            do
            {
                Console.WriteLine("##############################");
                Console.WriteLine("Welcome to OData V4 service: ");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. List all people");
                Console.WriteLine("2. View details for user");
                Console.WriteLine("3. Search for user");
                Console.WriteLine("Type 'end' to close program.");
                enter = Console.ReadLine();

                switch (enter)
                {
                    case "1":
                        Console.WriteLine(tripPinRESTierService.getPeople().value.toString<People>());
                        break;
                    case "2":
                        Console.WriteLine("Enter username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine(tripPinRESTierService.getUser(username).toString());
                        break;
                    case "3":
                        Console.WriteLine("Enter field to search: ");
                        string field = Console.ReadLine();
                        Console.WriteLine(field);
                        Console.WriteLine("Search: ");
                        string search = Console.ReadLine();
                        Console.WriteLine(tripPinRESTierService.searchUser(field, search).value.toString<People>());
                        break;
                }
            } while (enter != "end");
        }


    }
}
