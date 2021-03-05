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
    public class DrinkController : ControllerBase
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public DrinkController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }


        [HttpGet]
        public IEnumerable<DrinkViewModel> Get()
        {
            var Drinks = _servicesmanager.Drinks.GetDrinksList();

            return Drinks;
        }

        [HttpGet("{id}")]
        public ActionResult<DrinkViewModel> Get(int id)
        {
            var Drink = _servicesmanager.Drinks.DrinkDBToViewModelById(id);

            if (Drink == null)
            {
                return NotFound();
            }

            return Drink;
        }
        [HttpPost]
        public ActionResult<DrinkViewModel> Post(DrinkEditModel drink)
        {
            var drk = _servicesmanager.Drinks.SaveDrinkEditModelToDb(drink);

            if (drk == null)
            {
                return BadRequest();
            }

            return Ok(drk);
        }

        [HttpPut]
        public ActionResult<DrinkViewModel> Put(DrinkEditModel drink)
        {
            var drk = _servicesmanager.Drinks.SaveDrinkEditModelToDb(drink);
            if (drk == null)
            {
                return BadRequest();
            }
            return Ok(drk);
        }

        [HttpDelete("{id}")]
        public ActionResult<DrinkViewModel> Delete(int id)
        {
            var drk = _servicesmanager.Drinks.DrinkDBToViewModelById(id);

            if (drk == null)
            {
                return NotFound();
            }

            var drkList = _servicesmanager.Drinks.DeleteDrinkEditModelToDb(id);
            return Ok(drkList);
        }
    }
}
