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
    public class CoffeeMachineController : ControllerBase
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public CoffeeMachineController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }


        [HttpGet]
        public IEnumerable<CoffeeMachineViewModel> Get()
        {
            var CoffeeMachines = _servicesmanager.CoffeeMachines.GetCoffeeMachinesList();

            return CoffeeMachines;
        }

        [HttpGet("{id}")]
        public ActionResult<CoffeeMachineViewModel> Get(int id)
        {
            var CoffeeMachine = _servicesmanager.CoffeeMachines.CoffeeMachineDBToViewModelById(id);

            if (CoffeeMachine == null)
            {
                return NotFound();
            }

            return CoffeeMachine;
        }
        [HttpPost]
        public ActionResult<CoffeeMachineViewModel> Post(CoffeeMachineEditModel coffeeMachine)
        {
            var cfm = _servicesmanager.CoffeeMachines.SaveCoffeeMachineEditModelToDb(coffeeMachine);

            if (cfm == null)
            {
                return BadRequest();
            }

            
            return Ok(cfm);
        }

        [HttpPut]
        public ActionResult<CoffeeMachineViewModel> Put(CoffeeMachineEditModel coffeeMachine)
        {
            var cfm = _servicesmanager.CoffeeMachines.SaveCoffeeMachineEditModelToDb(coffeeMachine);
            if (cfm == null)
            {
                return BadRequest();
            }
            return Ok(cfm);
        }

        [HttpDelete("{id}")]
        public ActionResult<CoffeeMachineViewModel> Delete(int id)
        {
            var cfm = _servicesmanager.CoffeeMachines.CoffeeMachineDBToViewModelById(id);

            if (cfm == null)
            {
                return NotFound();
            }

            var cfmList = _servicesmanager.CoffeeMachines.DeleteCoffeeMachineEditModelToDb(id);
            return Ok(cfmList);
        }
    }
}
