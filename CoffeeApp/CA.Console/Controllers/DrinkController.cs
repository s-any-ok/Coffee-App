using CA.Service;
using CA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console.Controllers
{
    public class DrinkController
    {
        IServicesManager servicesManager;
        public DrinkController(IServicesManager serv)
        {
            servicesManager = serv;
        }
        public void GetIngredients(int id)
        {
            var drinks = servicesManager.Drinks.GetIngredients(id).ToList();
            drinks.ForEach(x =>
                System.Console.WriteLine("{0} - {1} - {2}", x.Id, x.IngredientName, x.Volume)
            );
        }
        public void GetIngredientsByCoffeeMachineId(int id)
        {
            var drinks = servicesManager.CoffeeMachines.GetDrinks(id).ToList();
            drinks.ForEach(x => {
                System.Console.WriteLine("{0}", x.DrinkName);
                GetIngredients(x.Id);
                }
            );
        }
    }
}
