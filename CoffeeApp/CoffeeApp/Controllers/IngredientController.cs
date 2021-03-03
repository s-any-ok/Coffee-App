using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeApp.BusinessLayer;
using CoffeeApp.DataLayer.Entityes;
using CoffeeApp.PresentationLayer;
using CoffeeApp.PresentationLayer.Models;
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
        public IEnumerable<IngredientViewModel> Get()
        {
            var Ingredients = _servicesmanager.Ingredients.GetIngredientsList();

            return Ingredients;
        }

        [HttpGet("{id}")]
        public ActionResult<IngredientViewModel> Get(int id)
        {
            var Ingredient = _servicesmanager.Ingredients.IngredientDBToViewModelById(id);

            if (Ingredient == null)
            {
                return NotFound();
            }

            return Ingredient;
        }
        [HttpPost]
        public ActionResult<IngredientEditModel> Post(IngredientEditModel ingredient)
        {
            var ing = _servicesmanager.Ingredients.SaveIngredientEditModelToDb(ingredient);

            if (ing == null)
            {
                return BadRequest();
            }

            
            return Ok(ing);
        }

        [HttpPut]
        public ActionResult<IngredientViewModel> Put(IngredientEditModel ingredient)
        {
            var ing = _servicesmanager.Ingredients.SaveIngredientEditModelToDb(ingredient);
            if (ing == null)
            {
                return BadRequest();
            }
            return Ok(ing);
        }

        [HttpDelete("{id}")]
        public ActionResult<IngredientViewModel> Delete(int id)
        {
            var ing = _servicesmanager.Ingredients.IngredientDBToViewModelById(id);

            if (ing == null)
            {
                return NotFound();
            }

            var ingList = _servicesmanager.Ingredients.DeleteIngredientsEditModelToDb(id);
            return Ok(ingList);
        }
    }
}
