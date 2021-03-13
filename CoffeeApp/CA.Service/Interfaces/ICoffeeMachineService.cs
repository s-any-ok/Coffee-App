using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service
{
    public interface ICoffeeMachineService
    {
        IEnumerable<CoffeeMachineDTO> GetAll();
        CoffeeMachineDTO GetById(int id);
        bool IsEnoughIngredients(int id);
        void AddCoffeeMachine(CoffeeMachineDTO coffeeMachineDTO);
        void EditCoffeeMachine(int id);
        void DeleteCoffeeMachine(int id);
        IEnumerable<DrinkDTO> GetDrinks(int id);
        DrinkDTO GetDrinkById(int id);
        IEnumerable<CoffeeMachineIngredientDTO> GetIngredients(int id, bool IsDefault);
    }
}
