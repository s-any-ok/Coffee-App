using System.Collections.Generic;
using CA.Data.Entityes;

namespace CA.Repo.Interfaces
{
    public interface ICoffeeMachineIngredientsRepository
    {
        IEnumerable<CoffeeMachineIngredient> GetAllByCoffeeMachineId(int id);
    }
}