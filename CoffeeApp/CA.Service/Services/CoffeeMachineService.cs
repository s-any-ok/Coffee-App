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
        //public List<CoffeeMachineViewModel> GetCoffeeMachinesList()
        //{
        //    var _cfm = _unitOfWork.CoffeeMachines.GetAll();
        //    List<CoffeeMachineViewModel> _modelsList = new List<CoffeeMachineViewModel>();
        //    foreach (var item in _cfm)
        //    {
        //        _modelsList.Add(CoffeeMachineDBToViewModelById(item.Id));
        //    }
        //    return _modelsList;
        //}
        //public CoffeeMachineDTO CoffeeMachineById(int CoffeeMachineId)
        //{
        //    var _coffeeMachine = _unitOfWork.CoffeeMachines.GetById(CoffeeMachineId);

        //    List<CoffeeMachineIngredientViewModel> _ingredientViewModelList = new List<CoffeeMachineIngredientViewModel>();
        //    List<DrinkViewModel> _drinkViewModelList = new List<DrinkViewModel>();
        //    if (_coffeeMachine != null)
        //    {
        //        if (_coffeeMachine.CoffeeMachineIngredients != null)
        //        {
        //            foreach (var item in _coffeeMachine.CoffeeMachineIngredients)
        //            {
        //                _ingredientViewModelList.Add(_ingredientsService.IngredientDBToViewModelById(item.Id));
        //            }
        //        }
        //        if (_coffeeMachine.Drinks != null)
        //        {
        //            foreach (var item in _coffeeMachine.Drinks)
        //            {
        //                _drinkViewModelList.Add(_drinksService.DrinkDBToViewModelById(item.Id));
        //            }
        //        }
        //    }

        //    return new CoffeeMachineViewModel() { CoffeeMachine = _coffeeMachine, Ingredients = _ingredientViewModelList, Drinks = _drinkViewModelList };
        //}
        //public CoffeeMachineEditModel GetCoffeeMachineEditModel(int CoffeeMachineid = 0)
        //{
        //    if (CoffeeMachineid != 0)
        //    {
        //        var _cfmDB = _unitOfWork.CoffeeMachines.GetById(CoffeeMachineid);
        //        var _cfmEditModel = new CoffeeMachineEditModel()
        //        {
        //            Id = _cfmDB.Id,
        //            Producer = _cfmDB.Producer,
        //            CoffeeMachineName = _cfmDB.CoffeeMachineName
        //        };
        //        return _cfmEditModel;
        //    }
        //    else { return new CoffeeMachineEditModel() { }; }
        //}
        //public CoffeeMachineViewModel SaveCoffeeMachineEditModelToDb(CoffeeMachineEditModel CoffeeMachineEditModel)
        //{
        //    CoffeeMachine _CoffeeMachineDbModel;
        //    if (CoffeeMachineEditModel.Id != 0)
        //    {
        //        _CoffeeMachineDbModel = _unitOfWork.CoffeeMachines.GetById(CoffeeMachineEditModel.Id);
        //    }
        //    else
        //    {
        //        _CoffeeMachineDbModel = new CoffeeMachine();
        //    }
        //    _CoffeeMachineDbModel.CoffeeMachineName = CoffeeMachineEditModel.CoffeeMachineName;
        //    _CoffeeMachineDbModel.Producer = CoffeeMachineEditModel.Producer;

        //    _unitOfWork.CoffeeMachines.Create(_CoffeeMachineDbModel);

        //    return CoffeeMachineDBToViewModelById(_CoffeeMachineDbModel.Id);
        //}

        //public List<CoffeeMachineViewModel> DeleteCoffeeMachineEditModelToDb(int CoffeeMachineId)
        //{
        //    var _coffeeMachine = _unitOfWork.CoffeeMachines.GetById(CoffeeMachineId);

        //    if (_coffeeMachine.Id != 0)
        //    {
        //        _unitOfWork.CoffeeMachines.Delete(_coffeeMachine);
        //    }

        //    return GetCoffeeMachinesList();
        //}
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

        IEnumerable<DrinkDTO> ICoffeeMachineService.GetDrinks()
        {
            throw new NotImplementedException();
        }

        DrinkDTO ICoffeeMachineService.GetDrinkById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CoffeeMachineIngredientDTO> ICoffeeMachineService.GetIngredients()
        {
            throw new NotImplementedException();
        }
    }
}
