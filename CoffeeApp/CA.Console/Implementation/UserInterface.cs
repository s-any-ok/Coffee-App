using System;
using CA.Console.Controllers;
using CoffeeApp.Console.Interfaces;

namespace CoffeeApp.Console.Implementation
{
    public class UserInterface : IUserInterface
    {
        private readonly CoffeeMachineConsoleWriter coffeeMachineConsoleWriter;
        private readonly DrinkConsoleWriter drinkConsoleWriter;
        private readonly OrderConsoleWriter orderConsoleWriter;

        public UserInterface(CoffeeMachineConsoleWriter coffeeMachineConsoleWriter, DrinkConsoleWriter drinkConsoleWriter, OrderConsoleWriter orderConsoleWriter)
        {
            this.coffeeMachineConsoleWriter = coffeeMachineConsoleWriter;
            this.drinkConsoleWriter = drinkConsoleWriter;
            this.orderConsoleWriter = orderConsoleWriter;
        }

        public void Show()
        {
            System.Console.WriteLine("Choose action:");
            System.Console.WriteLine("1 - Get all CoffeeMachines");
            System.Console.WriteLine("2 - Get CoffeeMachine by id");
            System.Console.WriteLine("3 - Make order");
            System.Console.WriteLine("4 - Get CoffeeMachines status");
            System.Console.WriteLine("5 - Get time to recharge ingredients");
            string input = System.Console.ReadLine();
            System.Console.Clear();
            if (input == "1")
            {
                coffeeMachineConsoleWriter.GetCoffeeMachines();
            }
            else if (input == "2")
            {
                System.Console.Clear();
                System.Console.WriteLine("Input id");
                string id = System.Console.ReadLine();
                int Id = Int32.Parse(id);
                System.Console.Clear();
                coffeeMachineConsoleWriter.LogCoffeeMachineById(Id);
                drinkConsoleWriter.LogDrinksWithIngredients(Id);
            }
            else if (input == "3") 
            {
                orderConsoleWriter.MakeOrder();           
            }
            else if (input == "4")
            {
                coffeeMachineConsoleWriter.LogCoffeeMachinesStatus();
            }
            else if (input == "5")
            {
                coffeeMachineConsoleWriter.LogTimeToRechargeCoffeeMachines();
            }
            else {
                Environment.Exit(1);
            }

            System.Console.ReadKey();
        }
    }
}