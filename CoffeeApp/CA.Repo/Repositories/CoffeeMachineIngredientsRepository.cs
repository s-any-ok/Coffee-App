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
    public class CoffeeMachineIngredientsRepository : Repository<CoffeeMachineIngredient>, ICoffeeMachineIngredientsRepository
    {
        public CoffeeMachineIngredientsRepository(EFDBContext _context) : base(_context) { }        
        public IEnumerable<CoffeeMachineIngredient> GetAllByCoffeeMachineId(int id)
        {
            return _context.CoffeeMachineIngredient.Where(ing => ing.CoffeeMachineId == id).Include(ing => ing.IngredientType).AsNoTracking();
        }
    }
}
