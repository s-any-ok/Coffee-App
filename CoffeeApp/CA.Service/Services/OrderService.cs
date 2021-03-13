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

        public bool IsCorrectOrder(OrderDTO orderDTO) 
        {
            var drink = _unitOfWork.Drinks.GetById(orderDTO.DrinkId);
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAll(drink.Id);

            var coffeeMachine = _unitOfWork.CoffeeMachines.GetById(orderDTO.DrinkId);
            var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAll(coffeeMachine.Id)
                .Where(i => i.IsDefault == false);

            foreach (var drinkIngredient in drinkIngredients)
            {
                foreach (var coffeeMachineIngredient in coffeeMachineIngredients)
                {
                    if (drinkIngredient.IngredientName == coffeeMachineIngredient.IngredientName)
                    {
                        if (coffeeMachineIngredient.Volume < drinkIngredient.Volume) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            var drink = _unitOfWork.Drinks.GetById(orderDTO.DrinkId);
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAll(drink.Id);

            var coffeeMachine = _unitOfWork.CoffeeMachines.GetById(orderDTO.DrinkId);
            var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAll(coffeeMachine.Id)
                .Where(i => i.IsDefault == false);

            foreach (var drinkIngredient in drinkIngredients)
            {
                foreach (var coffeeMachineIngredient in coffeeMachineIngredients)
                {
                    if (drinkIngredient.IngredientName == coffeeMachineIngredient.IngredientName) 
                    {
                        coffeeMachineIngredient.Volume -= drinkIngredient.Volume;
                        _unitOfWork.CoffeeMachineIngredients.Update(coffeeMachineIngredient);
                    }
                }
            }
            Console.WriteLine("Thank you for your ordering");
            var order = new Order() { DrinkId = orderDTO.DrinkId };
            _unitOfWork.Orders.Create(order);
            _unitOfWork.Save();
        }

        public void DeleteOrder(int id)
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
        }
    }
}
