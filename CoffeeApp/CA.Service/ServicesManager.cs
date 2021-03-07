using CA.Repo;
using CA.Service.Services;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service
{
    public class ServicesManager
    {
        UnitOfWork _unitOfWork;
        private CoffeeMachineService _coffeeMachineService;
        private DrinkService _drinkService;

        public ServicesManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _coffeeMachineService = new CoffeeMachineService(_unitOfWork);
            _drinkService = new DrinkService(_unitOfWork);
        }
        public CoffeeMachineService CoffeeMachines { get { return _coffeeMachineService; } }
        public DrinkService Drinks { get { return _drinkService; } }
    }
}
