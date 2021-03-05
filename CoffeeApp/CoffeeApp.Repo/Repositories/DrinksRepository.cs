using CoffeeApp.Repo.Interfaces;
using CoffeeApp.Data;
using CoffeeApp.Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Repo.Implementations
{
    public class DrinksRepository : IRepository<Drink>
    {
        private EFDBContext context;
        public DrinksRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Drink> GetAll()
        {
            //if (includeCoffeeMachine)
            //    return context.Set<Ingredient>().Include(x => x.CoffeeMachine).AsNoTracking().ToList();
            //else
                return context.Drink.ToList();
        }

        public Drink GetById(int drinkId)
        {
            //if (includeCoffeeMachine)
            //    return context.Set<Ingredient>().Include(x => x.CoffeeMachine).AsNoTracking().FirstOrDefault(x => x.Id == ingredientId);
            //else
                return context.Drink.FirstOrDefault(x => x.Id == drinkId);
        }

        public void Save(Drink drink)
        {
            if (drink.Id == 0)
                context.Drink.Add(drink);
            else
                context.Entry(drink).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Drink drink)
        {
            context.Drink.Remove(drink);
            context.SaveChanges();
        }
    }
}
