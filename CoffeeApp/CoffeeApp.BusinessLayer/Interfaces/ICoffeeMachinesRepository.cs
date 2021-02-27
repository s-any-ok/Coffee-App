using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.BusinessLayer.Interfaces
{
    public interface ICoffeeMachinesRepository
    {
        IEnumerable<CoffeeMachine> GetAll();
        CoffeeMachine GetById(int coffeeMachineId);
        void Save(CoffeeMachine coffeeMachine);
        void Delete(CoffeeMachine coffeeMachine);
    }
}
