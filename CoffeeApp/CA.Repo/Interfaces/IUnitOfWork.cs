using CA.Data.Entityes;
using CA.Repo.Implementations;
using CA.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Repo.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CoffeeMachinesRepository CoffeeMachines { get; }
        DrinksRepository Drinks { get; }
        CoffeeMachineIngredientsRepository CoffeeMachineIngredients { get; }
        OrdersRepository Orders { get; }
        DrinkIngredientsRepository DrinkIngredients { get; }
        IngredientTypesRepository IngredientTypes { get; }
        void Save();
        void Dispose();
    }
}
