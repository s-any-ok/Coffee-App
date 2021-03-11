using CA.Repo;
using CA.Data.Entityes;
using CA.Service.Models;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CA.Service.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private UnitOfWork _unitOfWork;
        public CoffeeMachineService(UnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }
        public IEnumerable<CoffeeMachineDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CoffeeMachine, CoffeeMachineDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CoffeeMachine>, List<CoffeeMachineDTO>>(_unitOfWork.CoffeeMachines.GetAll());
        }

        public CoffeeMachineDTO GetById(int id)
        {
            var coffeeMachine = _unitOfWork.CoffeeMachines.GetById(id);
            return new CoffeeMachineDTO { Id = coffeeMachine.Id, CoffeeMachineName = coffeeMachine.CoffeeMachineName, Producer = coffeeMachine.Producer };
        }

        void ICoffeeMachineService.AddCoffeeMachine(CoffeeMachineDTO coffeeMachineDTO)
        {
            throw new NotImplementedException();
        }

        void ICoffeeMachineService.EditCoffeeMachine(int id)
        {
            throw new NotImplementedException();
        }

        void ICoffeeMachineService.DeleteCoffeeMachine(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DrinkDTO> GetDrinks(int id)
        {
            var drinks = _unitOfWork.Drinks.GetAll();
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                drinks = _unitOfWork.Drinks.GetAll(id);
            }
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Drink, DrinkDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Drink>, List<DrinkDTO>>(drinks);
        }

        DrinkDTO ICoffeeMachineService.GetDrinkById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoffeeMachineIngredientDTO> GetIngredients(int id, bool isDefault)
        {
            var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAll().Where(i => i.isDefault == isDefault);
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAll(id).Where(i => i.isDefault == isDefault);
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CoffeeMachineIngredient, CoffeeMachineIngredientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CoffeeMachineIngredient>, List<CoffeeMachineIngredientDTO>>(coffeeMachineIngredients);
        }
    }
}
