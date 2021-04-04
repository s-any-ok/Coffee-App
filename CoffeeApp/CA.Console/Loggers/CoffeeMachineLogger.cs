using CA.Service;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console.Controllers
{
    public class CoffeeMachineLogger
    {
        private ICoffeeMachineService coffeeMachineService;
        public CoffeeMachineLogger()
        {
            coffeeMachineService = new CoffeeMachineService();
        }

        public void GetCoffeeMachines()
        {
            System.Console.Clear();
            var CoffeeMachines = coffeeMachineService.GetAll().ToList();
            CoffeeMachines.ForEach(x => 
                System.Console.WriteLine("{0} {1} {2}", x.Id, x.CoffeeMachineName, x.Producer)
            );
        }

        public void GetCoffeeMachineById(int id)
        {
            var CoffeeMachine = coffeeMachineService.GetById(id);
            System.Console.WriteLine("№{0} - {1} - {2}", CoffeeMachine.Id, CoffeeMachine.CoffeeMachineName, CoffeeMachine.Producer);
        }

        public void GetCoffeeMachineDrinks(int id)
        {
            var Drinks = coffeeMachineService.GetDrinks(id).ToList();
            Drinks.ForEach(x =>
                System.Console.WriteLine("№{0}a{1} {2}", id, x.Id, x.DrinkName)
            );
        }

        public void GetCoffeeMachineIngredients(int id, bool IsDefault)
        {
            var CoffeeMachines = coffeeMachineService.GetIngredients(id, IsDefault).ToList();
            CoffeeMachines.ForEach(x =>
                System.Console.WriteLine("{0} - {1}", x.IngredientName, x.Volume)
            );
        }

        public void GetCoffeeMachineIngredientsStatus(int id)
        {
            var defIngs = coffeeMachineService.GetIngredients(id, true).ToList();
            var curIngs = coffeeMachineService.GetIngredients(id, false).ToList();
            foreach (var defIng in defIngs)
            {
                foreach (var curIng in curIngs)
                {
                    if (defIng.IngredientName == curIng.IngredientName)
                    {
                        var proc = (100f * curIng.Volume) / defIng.Volume;
                        System.Console.WriteLine(string.Format(" {0,-10} {1,-8} {2,-8} {3}%", defIng.IngredientName, defIng.Volume, curIng.Volume, proc));
                    }
                }
            }
        }

        public void LogCoffeeMachineById(int id)
        {
            GetCoffeeMachineById(id);
            System.Console.WriteLine("Ingredients: ");
            GetCoffeeMachineIngredients(id, true);
            System.Console.WriteLine("Drinks: ");
            GetCoffeeMachineDrinks(id);
        }

        public void LogCoffeeMachinesStatus()
        {
            var CoffeeMachines = coffeeMachineService.GetAll().ToList();
            CoffeeMachines.ForEach(x => 
            {
                GetCoffeeMachineById(x.Id);
                System.Console.WriteLine("Ingredients: ");
                GetCoffeeMachineIngredientsStatus(x.Id);
                System.Console.WriteLine();
            }
            );
            
        }

        public void LogTimeToRechargeCoffeeMachines()
        {
            var CoffeeMachines = coffeeMachineService.GetAll().ToList();
            CoffeeMachines.ForEach(x =>
            {
                var time = coffeeMachineService.GetTimeToRefreshIngredients(x.Id);
                System.Console.WriteLine("{0} - {1}", x.Id, x.CoffeeMachineName);
                System.Console.WriteLine(string.Format("\t{0:%d} days, {0:%h} hours, {0:%m} minutes, {0:%s} seconds\n", time));
            }
            );

        }
    }
}
