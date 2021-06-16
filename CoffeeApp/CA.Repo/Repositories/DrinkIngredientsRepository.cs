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
    public class DrinkIngredientsRepository : Repository<DrinkIngredient, int>, IDrinkIngredientsRepository
    {
        public DrinkIngredientsRepository(EFDBContext _context) : base(_context) { }

        public IEnumerable<DrinkIngredient> GetAllByDrinkId(int id)
        {
            return _context.DrinkIngredient.Where(d => d.DrinkId == id).AsNoTracking();
        }
    }
}
