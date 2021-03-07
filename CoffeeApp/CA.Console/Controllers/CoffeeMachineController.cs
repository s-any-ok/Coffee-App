using CA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console.Controllers
{
    public class CoffeeMachineController
    {
        ICoffeeMachineService coffeeMachineService;
        public CoffeeMachineController(ICoffeeMachineService serv)
        {
            coffeeMachineService = serv;
        }

        public void GetCoffeeMachines()
        {
            var CoffeeMachines = coffeeMachineService.GetAll().ToList();
            CoffeeMachines.ForEach(x =>
                System.Console.WriteLine("{0} {1} {2}", x.Id, x.CoffeeMachineName, x.Producer)
            );
        }

        public void GetCoffeeMachineById(int id)
        {
            var CoffeeMachine = coffeeMachineService.GetById(id);
            System.Console.WriteLine("{0} {1} {2}", CoffeeMachine.Id, CoffeeMachine.CoffeeMachineName, CoffeeMachine.Producer);
        }
    }
}
