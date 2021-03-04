using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.BusinessLayer.Interfaces
{
    public interface ICoffeeMachineIngredientsRepository
    {
        IEnumerable<CoffeeMachineIngredient> GetAll();
        CoffeeMachineIngredient GetById(int ingredientId);
        void Save(CoffeeMachineIngredient ingredient);
        void Delete(CoffeeMachineIngredient ingredient);
    }
}
