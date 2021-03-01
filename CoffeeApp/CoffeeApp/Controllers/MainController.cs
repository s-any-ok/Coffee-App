using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoffeeApp.BusinessLayer;
using CoffeeApp.PresentationLayer;
using CoffeeApp.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using static CoffeeApp.DataLayer.Enums.MainEnums;

namespace CoffeeApp.Controllers
{
    public class MainController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public MainController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }
        public IActionResult Index(int pageId, PageType pageType)
        {
         
            switch (pageType)
            {
                case PageType.CoffeeMachine:
                    var CoffeeMachines = _servicesmanager.CoffeeMachines.CoffeeMachineDBToViewModelById(pageId);
                    return View(CoffeeMachines);
                    //break;
                case PageType.Ingredient:
                    var Ingredients = _servicesmanager.Ingredients.IngredientDBModelToView(pageId);
                    return View(Ingredients);
                //break;
                default: return View(null);/* break;*/
            }
            //ViewBag.PageType = pageType;
            //return View(_viewModel);
        }

        //[HttpGet]
        //public IActionResult PageEditor(int pageId, PageType pageType, int directoryId = 0)
        //{
        //    PageEditModel _editModel;

        //    switch (pageType)
        //    {
        //        case PageType.Directory:
        //            if (pageId != 0) _editModel = _servicesmanager.Directorys.GetDirectoryEdetModel(pageId);
        //            else _editModel = _servicesmanager.Directorys.CreateNewDirectoryEditModel();
        //            break;
        //        case PageType.Material:
        //            if (pageId != 0) _editModel = _servicesmanager.Materials.GetMaterialEdetModel(pageId);
        //            else _editModel = _servicesmanager.Materials.CreateNewMaterialEditModel(directoryId);
        //            break;
        //        default: _editModel = null; break;
        //    }

        //    ViewBag.PageType = pageType;
        //    return View(_editModel);
        //}

        //[HttpPost]
        //public IActionResult SaveDirectory(DirectoryEditModel model)
        //{
        //    _servicesmanager.Directorys.SaveDirectoryEditModelToDb(model);
        //    return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Directory });
        //}

        //[HttpPost]
        //public IActionResult SaveMaterial(MaterialEditModel model)
        //{
        //    _servicesmanager.Materials.SaveMaterialEditModelToDb(model);
        //    return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Material });
        //}
    }
}
