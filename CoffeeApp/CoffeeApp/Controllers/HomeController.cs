using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffeeApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var res = _dataManager.CoffeeMachines.GetAll().First();
            // CoffeeMachine _coff = new CoffeeMachine() { Id = 1, CoffeeMachineName = "Ok", Producer = "Nano" };
            return View(res);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
