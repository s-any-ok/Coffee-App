using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Service.Views;

namespace CA.Service
{
    public interface IDrinkService
    {
        
        IEnumerable<DrinkIngredientView> GetIngredients(int id);
        IEnumerable<OrderView> GetOrders(int id);
        IEnumerable<DrinkView> GetAll();

        #region NotImplemented

        /*IEnumerable<DrinkDTO> GetAll();
        DrinkDTO GetById(int id);
        void AddDrink(DrinkDTO drinkDTO);
        void EditDrink(int id);
        void DeleteDrink(int id);
        
        CoffeeMachineDTO GetCoffeeMachineById(int id);*/

        #endregion
    }
}
