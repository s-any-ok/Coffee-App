using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Repo.Interfaces
{
    public interface IDrinkIngredients : IRepository<DrinkIngredient, int>
    {
        IEnumerable<DrinkIngredient> GetAllByDrinkId(int id);
    }
}
