using CA.Repo.Interfaces;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Repo.Implementations;

namespace CA.Repo
{
    public class DataManager
    {
        private IRepository<CoffeeMachine> _coffeeMachinesRepository;
        private IRepository<CoffeeMachineIngredient> _coffeeMachineIngredientsRepository;
        private IRepository<Drink> _drinksRepository;

        public DataManager(IRepository<CoffeeMachine> coffeeMachinesRepository, IRepository<CoffeeMachineIngredient> coffeeMachineIngredientsRepository,
                            IRepository<Drink> drinksRepository)
        {
            _coffeeMachinesRepository = coffeeMachinesRepository;
            _coffeeMachineIngredientsRepository = coffeeMachineIngredientsRepository;
            _drinksRepository = drinksRepository;
        }

        public DataManager()
        {
            _coffeeMachinesRepository = new CoffeeMachinesRepository();
            _coffeeMachineIngredientsRepository = new CoffeeMachineIngredientsRepository();
            _drinksRepository = new DrinksRepository();
        }

        public IRepository<CoffeeMachine> CoffeeMachines { get { return _coffeeMachinesRepository; } }
        public IRepository<CoffeeMachineIngredient> CoffeeMachineIngredients { get { return _coffeeMachineIngredientsRepository; } }
        public IRepository<Drink> Drinks { get { return _drinksRepository; } }

    }
}
