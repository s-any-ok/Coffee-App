using CoffeeApp.BusinessLayer;
using CoffeeApp.PresentationLayer.Models;
using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.PresentationLayer.Services
{
    public class CoffeeMachineIngredientService
    {
        private DataManager _dataManager;
        public CoffeeMachineIngredientService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public List<CoffeeMachineIngredientViewModel> GetIngredientsList()
        {
            var _ing = _dataManager.CoffeeMachineIngredients.GetAll();
            List<CoffeeMachineIngredientViewModel> _modelsList = new List<CoffeeMachineIngredientViewModel>();
            foreach (var item in _ing)
            {
                _modelsList.Add(IngredientDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public CoffeeMachineIngredientViewModel IngredientDBToViewModelById(int IngredientId)
        {
            var _model = new CoffeeMachineIngredientViewModel()
            {
                CoffeeMachineIngredient = _dataManager.CoffeeMachineIngredients.GetById(IngredientId),
            };
            //var _cfm = _dataManager.CoffeeMachines.GetById(_model.Ingredient.CoffeeMachineId);
            //_model.Ingredient.CoffeeMachine = _cfm;

            //if (_ing.Ingredients.IndexOf(_ing.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) != _ing.Ingredients.Count() - 1)
            //{
            //    _model.NextIngredient = _ing.Ingredients.ElementAt(_ing.Ingredients.IndexOf(_ing.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) + 1);
            //}
            return _model;
        }

        public CoffeeMachineIngredientEditModel GetIngredientEditModel(int IngredientId)
        {
            var _dbModel = _dataManager.CoffeeMachineIngredients.GetById(IngredientId);
            var _editModel = new CoffeeMachineIngredientEditModel()
            {
                Id = _dbModel.Id,
                isDefault = _dbModel.isDefault,
                CoffeeMachineId = _dbModel.CoffeeMachineId,
                IngredientName = _dbModel.IngredientName,
                Volume = _dbModel.Volume
            };
            return _editModel;
        }

        public CoffeeMachineIngredientViewModel SaveIngredientEditModelToDb(CoffeeMachineIngredientEditModel editModel)
        {
            CoffeeMachineIngredient CoffeeMachineIngredient;
            if (editModel.Id != 0)
            {
                CoffeeMachineIngredient = _dataManager.CoffeeMachineIngredients.GetById(editModel.Id);
            }
            else
            {
                CoffeeMachineIngredient = new CoffeeMachineIngredient();
            }
            CoffeeMachineIngredient.IngredientName = editModel.IngredientName;
            CoffeeMachineIngredient.Volume = editModel.Volume;
            CoffeeMachineIngredient.CoffeeMachineId = editModel.CoffeeMachineId;
            _dataManager.CoffeeMachineIngredients.Save(CoffeeMachineIngredient);
            return IngredientDBToViewModelById(CoffeeMachineIngredient.Id);
        }
        public List<CoffeeMachineIngredientViewModel> DeleteIngredientsEditModelToDb(int ingredientId)
        {
            var _ingredient = _dataManager.CoffeeMachineIngredients.GetById(ingredientId);

            if (_ingredient.Id != 0)
            {
                _dataManager.CoffeeMachineIngredients.Delete(_ingredient);
            }

            return GetIngredientsList();
        }
        public CoffeeMachineIngredientEditModel CreateNewIngredientEditModel(int CoffeeMachineId)
        {
            return new CoffeeMachineIngredientEditModel() { CoffeeMachineId = CoffeeMachineId };
        }
    }
}
