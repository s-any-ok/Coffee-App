﻿using CA.Repo.Interfaces;
using CA.Data;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CA.Repo.Implementations
{
    public class CoffeeMachineIngredientsRepository : ICoffeeMachineIngredientsRepository
    {
        private EFDBContext context;
        public CoffeeMachineIngredientsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<CoffeeMachineIngredient> GetAll()
        {
            return context.CoffeeMachineIngredient.AsNoTracking();
        }
        
        public IEnumerable<CoffeeMachineIngredient> GetAllByCoffeeMachineId(int id)
        {
            return context.CoffeeMachineIngredient.Where(ing => ing.CoffeeMachineId == id).AsNoTracking();
        }

        public CoffeeMachineIngredient GetById(int ingredientId)
        {
                return context.CoffeeMachineIngredient.FirstOrDefault(x => x.Id == ingredientId);
        }

        public void Update(CoffeeMachineIngredient ingredient)
        {
            context.Entry(ingredient).State = EntityState.Modified;
        }

        public void Create(CoffeeMachineIngredient ingredient)
        {
            if (ingredient.Id == 0)
                context.CoffeeMachineIngredient.Add(ingredient);
            else
                context.Entry(ingredient).State = EntityState.Modified;
        }

        public void Delete(CoffeeMachineIngredient ingredient)
        {
            context.CoffeeMachineIngredient.Remove(ingredient);
        }
    }
}
