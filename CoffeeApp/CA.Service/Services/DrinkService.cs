using CA.Repo;
using CA.Service.Models;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Services
{
    public class DrinkService
    {
        private UnitOfWork _unitOfWork;
        public DrinkService(UnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        //public List<DrinkViewModel> GetDrinksList()
        //{
        //    var _drks = _unitOfWork.Drinks.GetAll();
        //    List<DrinkViewModel> _modelsList = new List<DrinkViewModel>();
        //    foreach (var item in _drks)
        //    {
        //        _modelsList.Add(DrinkDBToViewModelById(item.Id));
        //    }
        //    return _modelsList;
        //}

        //public DrinkViewModel DrinkDBToViewModelById(int drinkId)
        //{
        //    var _model = new DrinkViewModel()
        //    {
        //        Drink = _unitOfWork.Drinks.GetById(drinkId),
        //    };
        //    //var _cfm = _unitOfWork.CoffeeMachines.GetById(_model.Drink.CoffeeMachineId);
        //    //_model.Drink.CoffeeMachine = _cfm;

        //    //if (_ing.Ingredients.IndexOf(_ing.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) != _ing.Ingredients.Count() - 1)
        //    //{
        //    //    _model.NextIngredient = _ing.Ingredients.ElementAt(_ing.Ingredients.IndexOf(_ing.Ingredients.FirstOrDefault(x => x.Id == _model.Ingredient.Id)) + 1);
        //    //}
        //    return _model;
        //}

        //public DrinkEditModel GetDrinkEditModel(int DrinkId)
        //{
        //    var _dbModel = _unitOfWork.Drinks.GetById(DrinkId);
        //    var _editModel = new DrinkEditModel()
        //    {
        //        Id = _dbModel.Id = _dbModel.Id,
        //        CoffeeMachineId = _dbModel.CoffeeMachineId,
        //        DrinkName = _dbModel.DrinkName
        //    };
        //    return _editModel;
        //}

        //public DrinkViewModel SaveDrinkEditModelToDb(DrinkEditModel editModel)
        //{
        //    Drink Drink;
        //    if (editModel.Id != 0)
        //    {
        //        Drink = _unitOfWork.Drinks.GetById(editModel.Id);
        //    }
        //    else
        //    {
        //        Drink = new Drink();
        //    }
        //    Drink.DrinkName = editModel.DrinkName;
        //    Drink.CoffeeMachineId = editModel.CoffeeMachineId;
        //    _unitOfWork.Drinks.Create(Drink);
        //    return DrinkDBToViewModelById(Drink.Id);
        //}
        //public List<DrinkViewModel> DeleteDrinkEditModelToDb(int drinkId)
        //{
        //    var _drink = _unitOfWork.Drinks.GetById(drinkId);

        //    if (_drink.Id != 0)
        //    {
        //        _unitOfWork.Drinks.Delete(_drink);
        //    }

        //    return GetDrinksList();
        //}
        //public DrinkEditModel CreateNewIngredientEditModel(int drinkId)
        //{
        //    return new DrinkEditModel() { CoffeeMachineId = drinkId };
        //}
    }
}
