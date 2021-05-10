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
    public class DrinkService : IDrinkService
    {
        private UnitOfWork _unitOfWork;
        public DrinkService()
        {
            this._unitOfWork = new UnitOfWork();
        }
        
        public IEnumerable<DrinkIngredientView> GetIngredients(int id)
        {
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAll(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DrinkIngredient, DrinkIngredientView>()).CreateMapper();
            return mapper.Map<IEnumerable<DrinkIngredient>, List<DrinkIngredientView>>(drinkIngredients);
        }

        public IEnumerable<OrderView> GetOrders(int id)
        {
            var orders = _unitOfWork.Orders.GetAllByDrinkId(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderView>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderView>>(orders);
        }

        public IEnumerable<DrinkView> GetAll()
        {
            var drinks = _unitOfWork.Drinks.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Drink, DrinkView>()).CreateMapper();
            return mapper.Map<IEnumerable<Drink>, List<DrinkView>>(drinks);
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
