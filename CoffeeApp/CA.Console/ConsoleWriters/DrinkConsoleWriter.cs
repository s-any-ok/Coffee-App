using CA.Service;
using CA.Service.Interfaces;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console.Controllers
{
    public class DrinkConsoleWriter
    {
        private readonly ICoffeeMachineService coffeeMachineService;
        private readonly IDrinkService drinkService;
        // private CoffeeMachineConsoleWriter coffeeMachineConsoleWriter;
       
        public DrinkConsoleWriter(ICoffeeMachineService coffeeMachineService, IDrinkService drinkService)
        {
            this.coffeeMachineService = coffeeMachineService;
            this.drinkService = drinkService;
            // coffeeMachineConsoleWriter = new CoffeeMachineConsoleWriter();
        }
        public void GetIngredients(int id)
        {
            var drinks = drinkService.GetIngredients(id).ToList();
            drinks.ForEach(x =>
                System.Console.WriteLine("- {0} - {1}",  coffeeMachineService.GetIngredients(x.Id), x.Volume)
            );
        }
        public void GetIngredientsByCoffeeMachineId(int id)
        {
            var drinks = coffeeMachineService.GetDrinks(id).ToList();
            drinks.ForEach(x => {
                System.Console.WriteLine("{0}", x.DrinkName);
                GetIngredients(x.Id);
                }
            );
        }
        public void LogDrinksWithIngredients(int id)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Show drinks with ingredients");
            System.Console.WriteLine("2 - Show drink with ingredient by id");
            string drinkChoose = System.Console.ReadLine();
            System.Console.Clear();
            if (drinkChoose == "1")
            {
                System.Console.WriteLine("Drinks: ");
                GetIngredientsByCoffeeMachineId(id);
            }
            else if (drinkChoose == "2")
            {
                //coffeeMachineConsoleWriter.GetCoffeeMachineDrinks(id);
                string str = System.Console.ReadLine();
                string[] strNums = str.Split('a');
                int coffeeMachineId = Int32.Parse(strNums[0]);
                int drinkId = Int32.Parse(strNums[1]);
                //string drinkId = System.Console.ReadLine();
                //int drinkIdInt = Int32.Parse(drinkId);
                GetIngredients(drinkId);
            }
        }
    }
}
