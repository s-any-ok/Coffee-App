using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service
{
    public interface IDrinkService
    {
        IEnumerable<DrinkIngredientDTO> GetAll();
        DrinkIngredientDTO GetById(int id);
        void AddDrink(DrinkIngredientDTO drinkIngredientDTO);
        void EditDrink(int id);
        void DeleteDrink(int id);
        IEnumerable<DrinkIngredientDTO> GetIngredients(int id);
    }
}
