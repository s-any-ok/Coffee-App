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
        IRepository<CoffeeMachine> CoffeeMachines { get; }
        IDrinkRepository Drinks { get; }
        ICoffeeMachineIngredientsRepository CoffeeMachineIngredients { get; }
        IOrdersRepository Orders { get; }
        IDrinkIngredients DrinkIngredients { get; }
        IRepository<IngredientType> IngredientTypes { get; }
        void Save();
        void Dispose();
    }
}
