using CA.Console;
using CA.Console.Controllers;
using CA.Data;
using CA.Data.Entityes;
using CA.Repo;
using CA.Repo.Implementations;
using CA.Service;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineLogger coffeeMachineLogger = new CoffeeMachineLogger();
            DrinkLogger drinkLogger = new DrinkLogger();
            OrderLogger orderLogger = new OrderLogger();

            System.Console.WriteLine("Choose action:");
            System.Console.WriteLine("1 - Get all CoffeeMachines");
            System.Console.WriteLine("2 - Get CoffeeMachine by id");
            System.Console.WriteLine("3 - Make order");
            System.Console.WriteLine("4 - Get CoffeeMachines status");
            string input = System.Console.ReadLine();
            System.Console.Clear();
            if (input == "1")
            {
                coffeeMachineLogger.GetCoffeeMachines();
            }
            else if (input == "2")
            {
                System.Console.Clear();
                System.Console.WriteLine("Input id");
                string id = System.Console.ReadLine();
                int Id = Int32.Parse(id);
                System.Console.Clear();
                coffeeMachineLogger.LogCoffeeMachineById(Id);
                drinkLogger.LogDrinksWithIngredients(Id);
            }
            else if (input == "3") 
            {
                orderLogger.MakeOrder();
;           }
            else if (input == "4")
            {
                coffeeMachineLogger.LogCoffeeMachinesStatus();
            }
            else {
                Environment.Exit(1);
            }

            System.Console.ReadKey();
        }
    }
}
