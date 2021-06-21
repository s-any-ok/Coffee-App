using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CA.Data;
using CA.Data.Entityes;
using CA.Repo.Interfaces;

namespace CA.Repo.Repositories
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
