using CA.Service;
using CA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console.Controllers
{
    public class CoffeeMachineController
    {
        IServicesManager servicesManager;
        public CoffeeMachineController(IServicesManager serv)
        {
            servicesManager = serv;
        }

        public void GetCoffeeMachines()
        {
            var CoffeeMachines = servicesManager.CoffeeMachines.GetAll().ToList();
            CoffeeMachines.ForEach(x =>
                System.Console.WriteLine("{0} {1} {2}", x.Id, x.CoffeeMachineName, x.Producer)
            );
        }

        public void GetCoffeeMachineById(int id)
        {
            var CoffeeMachine = servicesManager.CoffeeMachines.GetById(id);
            System.Console.WriteLine("{0} {1} {2}", CoffeeMachine.Id, CoffeeMachine.CoffeeMachineName, CoffeeMachine.Producer);
        }

        public void GetCoffeeMachineDrinks(int id)
        {
            var CoffeeMachines = servicesManager.CoffeeMachines.GetDrinks(id).ToList();
            CoffeeMachines.ForEach(x =>
                System.Console.WriteLine("{0} {1}", x.Id, x.DrinkName)
            );
        }

        public void GetCoffeeMachineIngredients(int id, bool isDefault)
        {
            var CoffeeMachines = servicesManager.CoffeeMachines.GetIngredients(id, isDefault).ToList();
            CoffeeMachines.ForEach(x =>
                System.Console.WriteLine("{0} - {1} - {2}", x.Id, x.IngredientName, x.Volume)
            );
        }
    }
}
