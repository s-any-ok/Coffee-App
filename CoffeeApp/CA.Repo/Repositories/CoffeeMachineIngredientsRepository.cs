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

        public CoffeeMachineIngredientsRepository()
        {
            this.context = new EFDBContext();
        }
        public IEnumerable<CoffeeMachineIngredient> GetAll()
        {
            if (true)
                return context.Set<CoffeeMachineIngredient>().Include(x => x.CoffeeMachine).AsNoTracking().ToList();
            else
                return context.CoffeeMachineIngredient.ToList();
        }

        public CoffeeMachineIngredient GetById(int ingredientId)
        {
            if (true)
                return context.Set<CoffeeMachineIngredient>().Include(x => x.CoffeeMachine).AsNoTracking().FirstOrDefault(x => x.Id == ingredientId);
            else
                return context.CoffeeMachineIngredient.FirstOrDefault(x => x.Id == ingredientId);
        }

        public void Save(CoffeeMachineIngredient ingredient)
        {
            if (ingredient.Id == 0)
                context.CoffeeMachineIngredient.Add(ingredient);
            else
                context.Entry(ingredient).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(CoffeeMachineIngredient ingredient)
        {
            context.CoffeeMachineIngredient.Remove(ingredient);
            context.SaveChanges();
        }
    }
}
