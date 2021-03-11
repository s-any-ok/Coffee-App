﻿using CA.Repo.Interfaces;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Repo.Implementations;
using CA.Data;

namespace CA.Repo
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private EFDBContext db = new EFDBContext();
        private CoffeeMachinesRepository coffeeMachinesRepository;
        private DrinksRepository drinksRepository;
        private CoffeeMachineIngredientsRepository coffeeMachineIngredientsRepository;
        private DrinkIngredientsRepository drinkIngredientsRepository;

        public CoffeeMachinesRepository CoffeeMachines
        {
            get
            {
                if (coffeeMachinesRepository == null)
                    coffeeMachinesRepository = new CoffeeMachinesRepository(db);
                return coffeeMachinesRepository;
            }
        }
        public DrinksRepository Drinks
        {
            get
            {
                if (drinksRepository == null)
                    drinksRepository = new DrinksRepository(db);
                return drinksRepository;
            }
        }
        public CoffeeMachineIngredientsRepository CoffeeMachineIngredients
        {
            get
            {
                if (coffeeMachineIngredientsRepository == null)
                    coffeeMachineIngredientsRepository = new CoffeeMachineIngredientsRepository(db);
                return coffeeMachineIngredientsRepository;
            }
        }

        public DrinkIngredientsRepository DrinkIngredients
        {
            get
            {
                if (drinkIngredientsRepository == null)
                    drinkIngredientsRepository = new DrinkIngredientsRepository(db);
                return drinkIngredientsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
