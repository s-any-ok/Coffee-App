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
        public ConsoleManager()
        {
            _unitOfWork = new UnitOfWork();
            _servicesmanager = new ServicesManager(_unitOfWork);
            _coffeeMachineController = new CoffeeMachineController(_servicesmanager.CoffeeMachines);
        }

        public CoffeeMachineController CoffeeMachineController { get { return _coffeeMachineController; } }
    }
}
