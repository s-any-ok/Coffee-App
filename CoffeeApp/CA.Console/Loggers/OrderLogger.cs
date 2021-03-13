using CA.Data.Entityes;
using CA.Service;
using CA.Service.Models;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console.Controllers
{
    public class OrderLogger
    {
        ICoffeeMachineService coffeeMachineService;
        IDrinkService drinkService;
        IOrderService orderService;
        CoffeeMachineLogger coffeeMachineLogger;
        DrinkLogger drinkLogger;
        public OrderLogger()
        {
            coffeeMachineService = new CoffeeMachineService();
            drinkService = new DrinkService();
            orderService = new OrderService();
            coffeeMachineLogger = new CoffeeMachineLogger();
            drinkLogger = new DrinkLogger();
        }
        public void MakeOrder()
        {
            var CoffeeMachines = coffeeMachineService.GetAll().ToList();
            CoffeeMachines.ForEach(x =>
            {
                System.Console.WriteLine("---- {0} ----", x.CoffeeMachineName);
                coffeeMachineLogger.GetCoffeeMachineDrinks(x.Id);
                System.Console.WriteLine("\n\n");
            });
            System.Console.WriteLine();
            System.Console.WriteLine("Input drink number(№)");
            string number = System.Console.ReadLine();
            int numberInt = Int32.Parse(number);
            var order = new OrderDTO() { DrinkId = numberInt };
            if (orderService.IsCorrectOrder(order))
            {
                orderService.AddOrder(order);
            }
            else 
            {
                System.Console.WriteLine("Please choose other drink!");
            }
        }
    }
}
