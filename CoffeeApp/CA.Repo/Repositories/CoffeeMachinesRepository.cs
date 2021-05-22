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
    public class CoffeeMachinesRepository : Repository<CoffeeMachine>, ICoffeeMachineRepository
    {
        public CoffeeMachinesRepository(EFDBContext _context) : base(_context) { }
    }
}
