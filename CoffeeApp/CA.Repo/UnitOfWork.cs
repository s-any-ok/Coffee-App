using CA.Repo.Interfaces;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Repo.Implementations;
using CA.Data;
using CA.Repo.Repositories;

namespace CA.Repo
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly EFDBContext _context;
        public ICoffeeMachineRepository CoffeeMachines { get; }
        public IDrinkRepository Drinks { get; }
        public ICoffeeMachineIngredientsRepository CoffeeMachineIngredients { get; }
        public IDrinkIngredientsRepository DrinkIngredients { get; }
        public IOrdersRepository Orders { get; }
        public IIngredientTypesRepository IngredientTypes { get; }
        
        public UnitOfWork(EFDBContext context, ICoffeeMachineRepository coffeeMachineRepository,
            IDrinkRepository drinkRepository, ICoffeeMachineIngredientsRepository coffeeMachineIngredientsRepository,
            IDrinkIngredientsRepository drinkIngredientsRepository, IOrdersRepository orderRepository, IIngredientTypesRepository ingredientTypeRepository)
        {
            _context = context;
            CoffeeMachines = coffeeMachineRepository;
            Drinks = drinkRepository;
            CoffeeMachineIngredients = coffeeMachineIngredientsRepository;
            Orders= orderRepository;
            DrinkIngredients = drinkIngredientsRepository;
            IngredientTypes = ingredientTypeRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable Members

        private bool _disposed = false;
         
        protected virtual void CleabData(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                
            }
            _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            CleabData(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            CleabData(false);
        }
        
        /*public void Dispose()
        {
            _context.Dispose();
        }

        ~UnitOfWork()
        {
            Dispose();
        }*/

        #endregion
    }
}
