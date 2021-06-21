using CA.Data;
using CA.Data.Entityes;
using CA.Repo.Interfaces;

namespace CA.Repo.Repositories
{
    public class CoffeeMachinesRepository : Repository<CoffeeMachine, int>, ICoffeeMachineRepository
    {
        public CoffeeMachinesRepository(EFDBContext _context) : base(_context) { }
    }
}
