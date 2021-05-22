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
        private EFDBContext _db = new EFDBContext();
        private ICoffeeMachineRepository _coffeeMachinesRepository;
        private IDrinkRepository _drinksRepository;
        private ICoffeeMachineIngredientsRepository _coffeeMachineIngredientsRepository;
        private IDrinkIngredients _drinkIngredientsRepository;
        private IOrdersRepository _ordersRepository;
        private IIngredientTypesRepository _ingredientTypeRepository;

        public ICoffeeMachineRepository CoffeeMachines
        {
            get
            {
                if (_coffeeMachinesRepository == null)
                    _coffeeMachinesRepository = new CoffeeMachinesRepository(_db);
                return _coffeeMachinesRepository;
            }
        }
        public IDrinkRepository Drinks
        {
            get
            {
                if (_drinksRepository == null)
                    _drinksRepository = new DrinksRepository(_db);
                return _drinksRepository;
            }
        }
        public ICoffeeMachineIngredientsRepository CoffeeMachineIngredients
        {
            get
            {
                if (_coffeeMachineIngredientsRepository == null)
                    _coffeeMachineIngredientsRepository = new CoffeeMachineIngredientsRepository(_db);
                return _coffeeMachineIngredientsRepository;
            }
        }

        public IDrinkIngredients DrinkIngredients
        {
            get
            {
                if (_drinkIngredientsRepository == null)
                    _drinkIngredientsRepository = new DrinkIngredientsRepository(_db);
                return _drinkIngredientsRepository;
            }
        }

        public IOrdersRepository Orders
        {
            get
            {
                if (_ordersRepository == null)
                    _ordersRepository = new OrdersRepository(_db);
                return _ordersRepository;
            }
        }

        public IIngredientTypesRepository IngredientTypes
        {
            get
            {
                if (_ingredientTypeRepository == null)
                    _ingredientTypeRepository = new IngredientTypesRepository(_db);
                return _ingredientTypeRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        #region IDisposable Members

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                 _coffeeMachinesRepository = null;
                 _drinksRepository = null;
                 _coffeeMachineIngredientsRepository = null;
                 _drinkIngredientsRepository = null;
                 _ordersRepository = null;
                 _ingredientTypeRepository = null;
    }
            _db.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
