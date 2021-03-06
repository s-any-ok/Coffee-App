﻿using System.Collections.Generic;
using CA.Data.Entityes;

namespace CA.Repo.Interfaces
{
    public interface ICoffeeMachineIngredientsRepository : IRepository<CoffeeMachineIngredient, int>
    {
        IEnumerable<CoffeeMachineIngredient> GetAllByCoffeeMachineId(int id);
    }
}