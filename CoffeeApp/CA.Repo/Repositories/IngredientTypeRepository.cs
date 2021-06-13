using CA.Data;
using CA.Data.Entityes;
using CA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Repo.Repositories
{
    public class IngredientTypesRepository : Repository<IngredientType, int>, IIngredientTypesRepository
    {
        public IngredientTypesRepository(EFDBContext _context) : base(_context) { }
    }
}
