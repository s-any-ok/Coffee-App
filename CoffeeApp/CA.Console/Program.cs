using CA.Console;
using CA.Data;
using CA.Data.Entityes;
using CA.Repo;
using CA.Repo.Implementations;
using CA.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleManager controller = new ConsoleManager();

            System.Console.WriteLine("Choose action:");
            System.Console.WriteLine("1 - Get all CoffeeMachines");
            System.Console.WriteLine("2 - Get CoffeeMachine by id");
            string input = System.Console.ReadLine();
            if (input == "1")
            {
                controller.CoffeeMachineController.GetCoffeeMachines();
            }
            else if (input == "2")
            {
                System.Console.Clear();
                System.Console.WriteLine("Input id");
                string id = System.Console.ReadLine();
                int Id = Int32.Parse(id);
                controller.CoffeeMachineController.GetCoffeeMachineById(Id);
            }
            else {
                Environment.Exit(1);
            }

            System.Console.ReadKey();
        }
    }
}
