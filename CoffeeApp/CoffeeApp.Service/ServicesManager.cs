using CoffeeApp.Repo;
using CoffeeApp.Service.Services;
using CoffeeApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Service
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private CoffeeMachineService _coffeeMachineService;
        private CoffeeMachineIngredientService _coffeeMachineIngredientService;
        private DrinkService _drinkService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _coffeeMachineService = new CoffeeMachineService(_dataManager);
            _coffeeMachineIngredientService = new CoffeeMachineIngredientService(_dataManager);
            _drinkService = new DrinkService(_dataManager);
        }
        public CoffeeMachineService CoffeeMachines { get { return _coffeeMachineService; } }
        public CoffeeMachineIngredientService CoffeeMachineIngredients { get { return _coffeeMachineIngredientService; } }
        public DrinkService Drinks { get { return _drinkService; } }
    }
}
