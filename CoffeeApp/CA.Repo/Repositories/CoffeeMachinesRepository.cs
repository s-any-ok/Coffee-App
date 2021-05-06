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

        public IEnumerable<CoffeeMachine> GetAll()
        {
                return context.CoffeeMachine.AsNoTracking();
        }

        public CoffeeMachine GetById(int coffeeMachineId)
        {
                return context.CoffeeMachine.First(x => x.Id == coffeeMachineId);
        }

        public void Update(CoffeeMachine coffeeMachine)
        {
            context.Entry(coffeeMachine).State = EntityState.Modified;
        }

        public void Create(CoffeeMachine coffeeMachine)
        {
            if (coffeeMachine.Id == 0)
                context.CoffeeMachine.Add(coffeeMachine);
            else
                context.Entry(coffeeMachine).State = EntityState.Modified;
        }

        public void Delete(CoffeeMachine coffeeMachine)
        {
            context.CoffeeMachine.Remove(coffeeMachine);
        }
    }
}
