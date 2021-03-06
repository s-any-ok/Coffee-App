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
    public class CoffeeMachinesRepository : IRepository<CoffeeMachine>
    {

        private EFDBContext context;
        public CoffeeMachinesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public CoffeeMachinesRepository()
        {
            this.context = new EFDBContext();
        }

        public IEnumerable<CoffeeMachine> GetAll()
        {
            //if (true)
            //    return context.Set<CoffeeMachine>().Include(x => x.CoffeeMachineIngredients).Include(x => x.Drinks).AsNoTracking().ToList();
            //else
                return context.CoffeeMachine;
        }

        public CoffeeMachine GetById(int coffeeMachineId)
        {
            //if (true)
            //    return context.Set<CoffeeMachine>().Include(x => x.CoffeeMachineIngredients).Include(x => x.Drinks).AsNoTracking().FirstOrDefault(x => x.Id == coffeeMachineId);
            //else
                return context.CoffeeMachine.FirstOrDefault(x => x.Id == coffeeMachineId);
        }

        public void Save(CoffeeMachine coffeeMachine)
        {
            if (coffeeMachine.Id == 0)
                context.CoffeeMachine.Add(coffeeMachine);
            else
                context.Entry(coffeeMachine).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(CoffeeMachine coffeeMachine)
        {
            context.CoffeeMachine.Remove(coffeeMachine);
            context.SaveChanges();
        }
    }
}
