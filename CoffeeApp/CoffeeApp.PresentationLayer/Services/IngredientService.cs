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
        private DataManager dataManager;
        public IngredientService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IngredientViewModel IngredientDBModelToView(int IngredientId)
        {
            var _model = new IngredientViewModel()
            {
                Ingredient = dataManager.Ingredients.GetById(IngredientId),
            };
            var _ing = dataManager.CoffeeMachines.GetById(_model.Ingredient.CoffeeMachineId);

            //if (_dir.Ingredients.IndexOf(_dir.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) != _dir.Ingredients.Count() - 1)
            //{
            //    _model.NextIngredient = _dir.Ingredients.ElementAt(_dir.Ingredients.IndexOf(_dir.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) + 1);
            //}
            return _model;
        }

        public IngredientEditModel GetIngredientEditModel(int IngredientId)
        {
            var _dbModel = dataManager.Ingredients.GetById(IngredientId);
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
                Ingredient = dataManager.Ingredients.GetById(editModel.Id);
            }
            else
            {
                Ingredient = new Ingredient();
            }
            Ingredient.IngredientName = editModel.IngredientName;
            Ingredient.Volume = editModel.Volume;
            Ingredient.CoffeeMachineId = editModel.CoffeeMachineId;
            dataManager.Ingredients.Save(Ingredient);
            return IngredientDBModelToView(Ingredient.Id);
        }
        public IngredientEditModel CreateNewIngredientEditModel(int CoffeeMachineId)
        {
            return new IngredientEditModel() { CoffeeMachineId = CoffeeMachineId };
        }
    }
}
