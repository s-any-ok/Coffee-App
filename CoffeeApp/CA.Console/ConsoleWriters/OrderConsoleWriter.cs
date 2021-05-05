﻿using CA.Data.Entityes;
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
        private ICoffeeMachineService coffeeMachineService;
        private IOrderService orderService;
        private CoffeeMachineLogger coffeeMachineLogger;
        public OrderLogger()
        {
            coffeeMachineService = new CoffeeMachineService();
            orderService = new OrderService();
            coffeeMachineLogger = new CoffeeMachineLogger();
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
            string str = System.Console.ReadLine();
            string[] strNums = str.Split('a');
            int coffeeMachineId = Int32.Parse(strNums[0]);
            int drinkId = Int32.Parse(strNums[1]);
            var order = new OrderDTO() { DrinkId = drinkId, CoffeeMachineId = coffeeMachineId };
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