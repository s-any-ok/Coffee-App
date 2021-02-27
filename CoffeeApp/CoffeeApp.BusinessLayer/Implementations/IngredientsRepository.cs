using CoffeeApp.BusinessLayer.Interfaces;
using CoffeeApp.DataLayer;
using CoffeeApp.DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.BusinessLayer.Implementations
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private EFDBContext context;
        public IngredientsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Ingredient> GetAll()
        {
            //if (includeDirectory)
            //    return context.Set<Ingredient>().Include(x => x.CoffeeMachine).AsNoTracking().ToList();
            //else
                return context.Ingredient.ToList();
        }

        public Ingredient GetById(int ingredientId)
        {
            //if (includeDirectory)
            //    return context.Set<Ingredient>().Include(x => x.CoffeeMachine).AsNoTracking().FirstOrDefault(x => x.Id == ingredientId);
            //else
                return context.Ingredient.FirstOrDefault(x => x.Id == ingredientId);
        }

        public void Save(Ingredient ingredient)
        {
            if (ingredient.Id == 0)
                context.Ingredient.Add(ingredient);
            else
                context.Entry(ingredient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Ingredient ingredient)
        {
            context.Ingredient.Remove(ingredient);
            context.SaveChanges();
        }
    }
}
