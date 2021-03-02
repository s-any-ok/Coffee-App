using CoffeeApp.BusinessLayer;
using CoffeeApp.DataLayer.Entityes;
using CoffeeApp.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.PresentationLayer.Services
{
    public class CoffeeMachineService
    {
        private DataManager _dataManager;
        private IngredientService _ingredientsService;
        public CoffeeMachineService(DataManager dataManager)
        {
            this._dataManager = dataManager;
            _ingredientsService = new IngredientService(dataManager);
        }
        public List<CoffeeMachineViewModel> GetCoffeeMachinesList()
        {
            var _cfm = _dataManager.CoffeeMachines.GetAll();
            List<CoffeeMachineViewModel> _modelsList = new List<CoffeeMachineViewModel>();
            foreach (var item in _cfm)
            {
                _modelsList.Add(CoffeeMachineDBToViewModelById(item.Id));
            }
            return _modelsList;
        }
        public CoffeeMachineViewModel CoffeeMachineDBToViewModelById(int CoffeeMachineId)
        {
            var _coffeeMachine = _dataManager.CoffeeMachines.GetById(CoffeeMachineId);

            List<IngredientViewModel> _ingredientViewModelList = new List<IngredientViewModel>();
            if (_coffeeMachine != null)
            {
                foreach (var item in _coffeeMachine.Ingredients)
                {
                    _ingredientViewModelList.Add(_ingredientsService.IngredientDBToViewModelById(item.Id));
                }
            }

            return new CoffeeMachineViewModel() { CoffeeMachine = _coffeeMachine, Ingredients = _ingredientViewModelList };
        }
        public CoffeeMachineEditModel GetCoffeeMachineEditModel(int CoffeeMachineid = 0)
        {
            if (CoffeeMachineid != 0)
            {
                var _cfmDB = _dataManager.CoffeeMachines.GetById(CoffeeMachineid);
                var _cfmEditModel = new CoffeeMachineEditModel()
                {
                    Id = _cfmDB.Id,
                    Producer = _cfmDB.Producer,
                    CoffeeMachineName = _cfmDB.CoffeeMachineName
                };
                return _cfmEditModel;
            }
            else { return new CoffeeMachineEditModel() { }; }
        }
        public CoffeeMachineViewModel SaveCoffeeMachineEditModelToDb(CoffeeMachineEditModel CoffeeMachineEditModel)
        {
            CoffeeMachine _CoffeeMachineDbModel;
            if (CoffeeMachineEditModel.Id != 0)
            {
                _CoffeeMachineDbModel = _dataManager.CoffeeMachines.GetById(CoffeeMachineEditModel.Id);
            }
            else
            {
                _CoffeeMachineDbModel = new CoffeeMachine();
            }
            _CoffeeMachineDbModel.CoffeeMachineName = CoffeeMachineEditModel.CoffeeMachineName;
            _CoffeeMachineDbModel.Producer = CoffeeMachineEditModel.Producer;

            _dataManager.CoffeeMachines.Save(_CoffeeMachineDbModel);

            return CoffeeMachineDBToViewModelById(_CoffeeMachineDbModel.Id);
        }

        public List<CoffeeMachineViewModel> DeleteCoffeeMachineEditModelToDb(int CoffeeMachineId)
        {
            var _coffeeMachine = _dataManager.CoffeeMachines.GetById(CoffeeMachineId);

            if (_coffeeMachine.Id != 0)
            {
                _dataManager.CoffeeMachines.Delete(_coffeeMachine);
            }

            return GetCoffeeMachinesList();
        }
        public CoffeeMachineEditModel CreateNewCoffeeMachineEditModel()
        {
            return new CoffeeMachineEditModel() { };
        }
    }
}
