using CA.Repo;
using CA.Service.Models;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CA.Service.Mappers;

namespace CA.Service.Services
{
    public class DrinkService : IDrinkService
    {
        private UnitOfWork _unitOfWork;
        public DrinkService()
        {
            this._unitOfWork = new UnitOfWork();
        }
        
        public IEnumerable<DrinkIngredientView> GetIngredients(int id)
        {
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAllByDrinkId(id);
            List<DrinkIngredientView> drinkIngredientViews = new List<DrinkIngredientView>();
            foreach (var drinkIngredient in drinkIngredients)
                drinkIngredientViews.Add(DrinkIngredientEntityViewMappper.MapToView(drinkIngredient));
            return drinkIngredientViews;
        }

        public IEnumerable<OrderView> GetOrders(int id)
        {
            var orders = _unitOfWork.Orders.GetAllByDrinkId(id);
            List<OrderView> orderViews = new List<OrderView>();
            foreach (var order in orders)
                orderViews.Add(OrderEntityViewMappper.MapToView(order));
            return orderViews;
        }

        public IEnumerable<DrinkView> GetAll()
        {
            var drinks = _unitOfWork.Drinks.GetAll();
            List<DrinkView> drinkViews = new List<DrinkView>();
            foreach (var drink in drinks)
                drinkViews.Add(DrinkEntityViewMappper.MapToView(drink));
            return drinkViews;
        }


        #region NotImplemented

        /*public CoffeeMachineDTO GetCoffeeMachineById(int id)
        {
            throw new NotImplementedException();
        }
        
        public void AddDrink(DrinkDTO drinkIngredientDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteDrink(int id)
        {
            throw new NotImplementedException();
        }

        public void EditDrink(int id)
        {
            throw new NotImplementedException();
        }

        public DrinkDTO GetById(int id)
        {
            throw new NotImplementedException();
        }*/

        #endregion
    }
}
