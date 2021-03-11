using CA.Console.Controllers;
using CA.Repo;
using CA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console
{
    public class ConsoleManager
    {
        private UnitOfWork _unitOfWork;
        private ServicesManager _servicesmanager;
        private CoffeeMachineController _coffeeMachineController;
        private DrinkController _drinkController;
        private OrderController _orderController;

        public ConsoleManager()
        {
            _unitOfWork = new UnitOfWork();
            _servicesmanager = new ServicesManager(_unitOfWork);
            _coffeeMachineController = new CoffeeMachineController(_servicesmanager);
            _drinkController = new DrinkController(_servicesmanager);
            _orderController = new OrderController(_servicesmanager);
        }

        public CoffeeMachineController CoffeeMachineController { get { return _coffeeMachineController; } }
        public DrinkController DrinkController { get { return _drinkController; } }
        public OrderController OrderController { get { return _orderController; } }
    }
}
