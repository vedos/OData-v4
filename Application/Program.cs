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
                string result = string.Empty;
                switch (enter)
                {
                    case "1":
                        result = tripPinRESTierService.getPeople()?.value.toString<People>();
                        if (result == null)
                            Console.WriteLine("No Data");
                        else
                            Console.WriteLine(result);
                        break;
                    case "2":
                        Console.WriteLine("Enter username: ");
                        string username = Console.ReadLine();
                        result = tripPinRESTierService.getUser(username)?.toString();
                        if (result == null)
                            Console.WriteLine("No Data");
                        else
                            Console.WriteLine(result);
                        break;
                    case "3":
                        Console.WriteLine("Enter field to search: ");
                        string field = Console.ReadLine();
                        Console.WriteLine(field);
                        Console.WriteLine("Search: ");
                        string search = Console.ReadLine();

                        result = tripPinRESTierService.searchUser(field, search)?.value.toString<People>();
                        if (result == null)
                            Console.WriteLine("No Data");
                        else
                            Console.WriteLine(result);
                        break;
                }
            } while (enter != "end");
        }


    }
}
