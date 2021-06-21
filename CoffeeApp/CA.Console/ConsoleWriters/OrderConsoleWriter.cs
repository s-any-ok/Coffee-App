using CA.Data.Entityes;
using CA.Service;
using CA.Service.Models;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Service.Views;

namespace CA.Console.Controllers
{
    public class OrderConsoleWriter
    {
        private readonly ICoffeeMachineService coffeeMachineService;
        private readonly IOrderService orderService;

        // private CoffeeMachineConsoleWriter coffeeMachineConsoleWriter;
        public OrderConsoleWriter(ICoffeeMachineService coffeeMachineService, IOrderService orderService)
        {
            this.coffeeMachineService = coffeeMachineService;
            this.orderService = orderService;
            // coffeeMachineConsoleWriter = new CoffeeMachineConsoleWriter();
        }
        public void MakeOrder()
        {
            var CoffeeMachines = coffeeMachineService.GetAll().ToList();
            CoffeeMachines.ForEach(x =>
            {
                System.Console.WriteLine("---- {0} ----", x.CoffeeMachineName);
                //coffeeMachineConsoleWriter.GetCoffeeMachineDrinks(x.Id);
                System.Console.WriteLine("\n\n");
            });
            System.Console.WriteLine();
            System.Console.WriteLine("Input drink number(№)");
            string str = System.Console.ReadLine();
            string[] strNums = str.Split('a');
            int coffeeMachineId = Int32.Parse(strNums[0]);
            int drinkId = Int32.Parse(strNums[1]);
            var order = new OrderView() { DrinkId = drinkId, CoffeeMachineId = coffeeMachineId };
            if (orderService.IsCorrectOrder(order))
            {
                orderService.AddOrder(order);
                System.Console.WriteLine("Thank you for your ordering");
            }
            else 
            {
                System.Console.WriteLine("Please choose other drink!");
            }
        }
    }
}
