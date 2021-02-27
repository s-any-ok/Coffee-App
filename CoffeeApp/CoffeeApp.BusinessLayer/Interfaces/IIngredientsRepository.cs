using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.BusinessLayer.Interfaces
{
    public interface IIngredientsRepository
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient GetById(int ingredientId);
        void Save(Ingredient ingredient);
        void Delete(Ingredient ingredient);
    }
}
