using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Interfaces
{
    public interface IServicesManager
    {
        CoffeeMachineService CoffeeMachines { get; }
        DrinkService Drinks { get; }
    }
}
