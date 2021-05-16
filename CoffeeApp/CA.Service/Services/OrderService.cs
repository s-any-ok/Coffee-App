using CA.Repo;
using CA.Service.Models;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CA.Service.Services
{
    public class OrderService : IOrderService
    {
        private UnitOfWork _unitOfWork;
        public OrderService()
        {
            this._unitOfWork = new UnitOfWork();
        }

        public bool IsCorrectOrder(OrderView order) 
        {
            var drink = _unitOfWork.Drinks.GetById(order.DrinkId);
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAllByDrinkId(drink.Id);

            var coffeeMachine = _unitOfWork.CoffeeMachines.GetById(order.DrinkId);
            var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAllByCoffeeMachineId(coffeeMachine.Id);

            foreach (var drinkIngredient in drinkIngredients)
            {
                foreach (var coffeeMachineIngredient in coffeeMachineIngredients)
                {
                    if (drinkIngredient.IngredientTypeId == coffeeMachineIngredient.IngredientTypeId)
                    {
                        if (coffeeMachineIngredient.Volume < drinkIngredient.Volume) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void AddOrder(OrderView order)
        {
            var drink = _unitOfWork.Drinks.GetById(order.DrinkId);
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAllByDrinkId(drink.Id);

            var coffeeMachine = _unitOfWork.CoffeeMachines.GetById(order.CoffeeMachineId);
            var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAllByCoffeeMachineId(coffeeMachine.Id);

            foreach (var drinkIngredient in drinkIngredients)
            {
                foreach (var coffeeMachineIngredient in coffeeMachineIngredients)
                {
                    if (drinkIngredient.IngredientTypeId == coffeeMachineIngredient.IngredientTypeId) 
                    {
                        coffeeMachineIngredient.Volume -= drinkIngredient.Volume;
                        _unitOfWork.CoffeeMachineIngredients.Update(coffeeMachineIngredient);
                    }
                }
            }
            
            var newOrder = new Order() { DrinkId = order.DrinkId, CoffeeMachineId = order.CoffeeMachineId };
            _unitOfWork.Orders.Create(newOrder);
            _unitOfWork.Save();
        }

        public DateTime GetFirstOrderDate(int id) => _unitOfWork.Orders.GetFirstOrder(id).OrderDate;
        public DateTime GetLastOrderDate(int id) => _unitOfWork.Orders.GetLastOrder(id).OrderDate;
        #region NotImplemented

        /*public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDTO GetById(int id)
        {
            throw new NotImplementedException();
        }*/

        #endregion
    }
}
