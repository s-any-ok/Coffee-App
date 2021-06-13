using CA.Repo.Interfaces;
using CA.Data;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CA.Repo.Repositories;

namespace CA.Repo.Implementations
{
    public class DrinksRepository : Repository<Drink, int>, IDrinkRepository
    {
        public DrinksRepository(EFDBContext _context) : base(_context) { }

        public IEnumerable<Drink> GetAllByCoffeeMachineId(int id)
        {
            return _context.CoffeeMachine.Where(c => c.Id == id).SelectMany(c => c.Drinks).AsNoTracking();
        }
    }
}
