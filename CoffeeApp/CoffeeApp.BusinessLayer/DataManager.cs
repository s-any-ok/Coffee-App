using CoffeeApp.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.BusinessLayer
{
    public class DataManager
    {
        private ICoffeeMachinesRepository _coffeeMachinesRepository;
        private ICoffeeMachineIngredientsRepository _coffeeMachineIngredientsRepository;
        private IDrinksRepository _drinksRepository;

        public DataManager(ICoffeeMachinesRepository coffeeMachinesRepository, ICoffeeMachineIngredientsRepository coffeeMachineIngredientsRepository,
                            IDrinksRepository drinksRepository)
        {
            _coffeeMachinesRepository = coffeeMachinesRepository;
            _coffeeMachineIngredientsRepository = coffeeMachineIngredientsRepository;
            _drinksRepository = drinksRepository;
        }

        public ICoffeeMachinesRepository CoffeeMachines { get { return _coffeeMachinesRepository; } }
        public ICoffeeMachineIngredientsRepository CoffeeMachineIngredients { get { return _coffeeMachineIngredientsRepository; } }
        public IDrinksRepository Drinks { get { return _drinksRepository; } }

    }
}
