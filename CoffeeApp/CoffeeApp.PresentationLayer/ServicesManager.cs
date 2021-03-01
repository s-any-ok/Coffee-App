using CoffeeApp.BusinessLayer;
using CoffeeApp.PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private CoffeeMachineService _coffeeMachineService;
        private IngredientService _ingredientService;

        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
            _coffeeMachineService = new CoffeeMachineService(_dataManager);
            _ingredientService = new IngredientService(_dataManager);
        }
        public CoffeeMachineService CoffeeMachines { get { return _coffeeMachineService; } }
        public IngredientService Ingredients { get { return _ingredientService; } }
    }
}
