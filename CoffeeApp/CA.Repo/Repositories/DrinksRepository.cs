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
    public class DrinksRepository : IDrinkRepository
    {
        private EFDBContext context;
        public DrinksRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Drink> GetAll()
        {
                return context.Drink.AsNoTracking();
        }

        public IEnumerable<Drink> GetAllByCoffeeMachineId(int id)
        {
            return context.CoffeeMachine.Where(c => c.Id == id).SelectMany(c => c.Drinks).AsNoTracking();
        }

        public Drink GetById(int drinkId)
        {
                return context.Drink.FirstOrDefault(x => x.Id == drinkId);
        }

        public void Update(Drink drink)
        {
            context.Entry(drink).State = EntityState.Modified;
        }

        public void Create(Drink drink)
        {
            if (drink.Id == 0)
                context.Drink.Add(drink);
            else
                context.Entry(drink).State = EntityState.Modified;
        }

        public void Delete(Drink drink)
        {
            context.Drink.Remove(drink);
        }
    }
}
