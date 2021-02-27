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

        public DataManager(ICoffeeMachinesRepository coffeeMachinesRepository, IIngredientsRepository ingredientsRepository)
        {
            _coffeeMachinesRepository = coffeeMachinesRepository;
            _ingredientsRepository = ingredientsRepository;
        }

        public ICoffeeMachinesRepository CoffeeMachines { get { return _coffeeMachinesRepository; } }
        public IIngredientsRepository Ingredients { get { return _ingredientsRepository; } }

    }
}
