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
        private IIngredientsRepository _ingredientsRepository;
        private IDrinksRepository _drinksRepository;

        public DataManager(ICoffeeMachinesRepository coffeeMachinesRepository, IIngredientsRepository ingredientsRepository,
                            IDrinksRepository drinksRepository)
        {
            _coffeeMachinesRepository = coffeeMachinesRepository;
            _ingredientsRepository = ingredientsRepository;
            _drinksRepository = drinksRepository;
        }

        public ICoffeeMachinesRepository CoffeeMachines { get { return _coffeeMachinesRepository; } }
        public IIngredientsRepository Ingredients { get { return _ingredientsRepository; } }
        public IDrinksRepository Drinks { get { return _drinksRepository; } }

    }
}
