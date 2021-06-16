using CA.Repo;
using CA.Service.Models;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CA.Repo.Interfaces;
using CA.Service.Mappers;

namespace CA.Service.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrinkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IEnumerable<DrinkIngredientView> GetIngredients(int id)
        {
            return _unitOfWork.DrinkIngredients.GetAllByDrinkId(id).Select(DrinkIngredientEntityViewMappper.MapToView);
        }

        public IEnumerable<OrderView> GetOrders(int id)
        {
            return _unitOfWork.Orders.GetAllByDrinkId(id).Select(OrderEntityViewMappper.MapToView);
        }

        public IEnumerable<DrinkView> GetAll()
        {
            return _unitOfWork.Drinks.GetAll().Select(DrinkEntityViewMappper.MapToView);
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
