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
    public class DrinkIngredientsRepository : IRepository<DrinkIngredient>
    {
        private EFDBContext context;
        public DrinkIngredientsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<DrinkIngredient> GetAll()
        {
                return context.DrinkIngredient.ToList();
        }

        public IEnumerable<DrinkIngredient> GetAll(int id)
        {
            return context.DrinkIngredient.Where(d => d.DrinkId == id);
        }

        public DrinkIngredient GetById(int ingredientId)
        {
                return context.DrinkIngredient.FirstOrDefault(x => x.Id == ingredientId);
        }

        public void Update(DrinkIngredient ingredient)
        {
            context.Entry(ingredient).State = EntityState.Modified;
        }

        public void Create(DrinkIngredient ingredient)
        {
            if (ingredient.Id == 0)
                context.DrinkIngredient.Add(ingredient);
            else
                context.Entry(ingredient).State = EntityState.Modified;
        }

        public void Delete(DrinkIngredient ingredient)
        {
            context.DrinkIngredient.Remove(ingredient);
        }
    }
}
