using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Repo.Interfaces
{
    public interface IDrinkRepository : IRepository<Drink>
    {
        IEnumerable<Drink> GetAllByCoffeeMachineId(int id);
    }
}
