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
        
        public IEnumerable<DrinkIngredientDTO> GetIngredients(int id)
        {
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAll(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DrinkIngredient, DrinkIngredientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DrinkIngredient>, List<DrinkIngredientDTO>>(drinkIngredients);
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

        public IEnumerable<DrinkDTO> GetAll()
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
