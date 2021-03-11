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
        public DrinkService(UnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public void AddDrink(DrinkIngredientDTO drinkIngredientDTO)
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

        public IEnumerable<DrinkIngredientDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public DrinkIngredientDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DrinkIngredientDTO> GetIngredients(int id)
        {
            var drinkIngredients = _unitOfWork.DrinkIngredients.GetAll();
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                drinkIngredients = _unitOfWork.DrinkIngredients.GetAll(id);
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DrinkIngredient, DrinkIngredientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DrinkIngredient>, List<DrinkIngredientDTO>>(drinkIngredients);
        }
    }
}
