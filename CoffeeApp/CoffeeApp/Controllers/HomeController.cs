using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // CoffeeMachine _coff = new CoffeeMachine() { Id = 1, CoffeeMachineName = "Ok", Producer = "Nano" };
            return View('g');
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
