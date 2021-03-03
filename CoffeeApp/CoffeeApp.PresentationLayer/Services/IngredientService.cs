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
    public class IngredientService
    {
        private DataManager _dataManager;
        public IngredientService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public List<IngredientViewModel> GetIngredientsList()
        {
            var _ing = _dataManager.Ingredients.GetAll();
            List<IngredientViewModel> _modelsList = new List<IngredientViewModel>();
            foreach (var item in _ing)
            {
                _modelsList.Add(IngredientDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public IngredientViewModel IngredientDBToViewModelById(int IngredientId)
        {
            var _model = new IngredientViewModel()
            {
                Ingredient = _dataManager.Ingredients.GetById(IngredientId),
            };
            //var _cfm = _dataManager.CoffeeMachines.GetById(_model.Ingredient.CoffeeMachineId);
            //_model.Ingredient.CoffeeMachine = _cfm;

            //if (_ing.Ingredients.IndexOf(_ing.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) != _ing.Ingredients.Count() - 1)
            //{
            //    _model.NextIngredient = _ing.Ingredients.ElementAt(_ing.Ingredients.IndexOf(_ing.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) + 1);
            //}
            return _model;
        }

        public IngredientEditModel GetIngredientEditModel(int IngredientId)
        {
            var _dbModel = _dataManager.Ingredients.GetById(IngredientId);
            var _editModel = new IngredientEditModel()
            {
                Id = _dbModel.Id = _dbModel.Id,
                CoffeeMachineId = _dbModel.CoffeeMachineId,
                IngredientName = _dbModel.IngredientName,
                Volume = _dbModel.Volume
            };
            return _editModel;
        }

        public IngredientViewModel SaveIngredientEditModelToDb(IngredientEditModel editModel)
        {
            Ingredient Ingredient;
            if (editModel.Id != 0)
            {
                Ingredient = _dataManager.Ingredients.GetById(editModel.Id);
            }
            else
            {
                Ingredient = new Ingredient();
            }
            Ingredient.IngredientName = editModel.IngredientName;
            Ingredient.Volume = editModel.Volume;
            Ingredient.CoffeeMachineId = editModel.CoffeeMachineId;
            _dataManager.Ingredients.Save(Ingredient);
            return IngredientDBToViewModelById(Ingredient.Id);
        }
        public List<IngredientViewModel> DeleteIngredientsEditModelToDb(int ingredientId)
        {
            var _ingredient = _dataManager.Ingredients.GetById(ingredientId);

            if (_ingredient.Id != 0)
            {
                _dataManager.Ingredients.Delete(_ingredient);
            }

            return GetIngredientsList();
        }
        public IngredientEditModel CreateNewIngredientEditModel(int CoffeeMachineId)
        {
            return new IngredientEditModel() { CoffeeMachineId = CoffeeMachineId };
        }
    }
}
