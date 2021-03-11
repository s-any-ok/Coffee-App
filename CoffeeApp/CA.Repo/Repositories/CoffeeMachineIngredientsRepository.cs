using CA.Repo.Interfaces;
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
    public class CoffeeMachineIngredientsRepository : IRepository<CoffeeMachineIngredient>
    {
        private EFDBContext context;
        public CoffeeMachineIngredientsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<CoffeeMachineIngredient> GetAll()
        {
                return context.CoffeeMachineIngredient.ToList();
        }

        public IEnumerable<CoffeeMachineIngredient> GetAll(int id)
        {
            return context.CoffeeMachineIngredient.Where(d => d.CoffeeMachineId == id);
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
