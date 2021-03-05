using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeApp.Repo;
using CoffeeApp.Data.Entityes;
using CoffeeApp.Service;
using CoffeeApp.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public IngredientController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }


        [HttpGet]
        public IEnumerable<CoffeeMachineIngredientViewModel> Get()
        {
            var Ingredients = _servicesmanager.CoffeeMachineIngredients.GetIngredientsList();

            return Ingredients;
        }

        [HttpGet("{id}")]
        public ActionResult<CoffeeMachineIngredientViewModel> Get(int id)
        {
            var Ingredient = _servicesmanager.CoffeeMachineIngredients.IngredientDBToViewModelById(id);

            if (Ingredient == null)
            {
                return NotFound();
            }

            return Ingredient;
        }
        [HttpPost]
        public ActionResult<CoffeeMachineIngredientEditModel> Post(CoffeeMachineIngredientEditModel ingredient)
        {
            var ing = _servicesmanager.CoffeeMachineIngredients.SaveIngredientEditModelToDb(ingredient);

            if (ing == null)
            {
                return BadRequest();
            }

            
            return Ok(ing);
        }

        [HttpPut]
        public ActionResult<CoffeeMachineIngredientViewModel> Put(CoffeeMachineIngredientEditModel ingredient)
        {
            var ing = _servicesmanager.CoffeeMachineIngredients.SaveIngredientEditModelToDb(ingredient);
            if (ing == null)
            {
                return BadRequest();
            }
            return Ok(ing);
        }

        [HttpDelete("{id}")]
        public ActionResult<CoffeeMachineIngredientViewModel> Delete(int id)
        {
            var ing = _servicesmanager.CoffeeMachineIngredients.IngredientDBToViewModelById(id);

            if (ing == null)
            {
                return NotFound();
            }

            var ingList = _servicesmanager.CoffeeMachineIngredients.DeleteIngredientsEditModelToDb(id);
            return Ok(ingList);
        }
    }
}
