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
        IEnumerable<DrinkDTO> GetAll();
        DrinkDTO GetById(int id);
        void AddDrink(DrinkDTO drinkDTO);
        void EditDrink(int id);
        void DeleteDrink(int id);
        IEnumerable<DrinkIngredientDTO> GetIngredients(int id);
        CoffeeMachineDTO GetCoffeeMachineById(int id);
    }
}
