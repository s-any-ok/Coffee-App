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
        
        IEnumerable<DrinkDTO> GetDrinks(int id);
        
        IEnumerable<CoffeeMachineIngredientDTO> GetIngredients(int id);
        TimeSpan GetTimeToRefreshIngredients(int id);

        #region NotImplemented
        /*void AddCoffeeMachine(CoffeeMachineDTO coffeeMachineDTO);
        void EditCoffeeMachine(int id);
        void DeleteCoffeeMachine(int id);
        DrinkDTO GetDrinkById(int id);*/
        #endregion
    }
}
