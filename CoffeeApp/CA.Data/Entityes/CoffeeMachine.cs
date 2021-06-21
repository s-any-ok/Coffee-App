using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Data.Entityes.Base;

namespace CA.Data.Entityes
{
    public class CoffeeMachine : BaseEntity<int>
    {
        public string CoffeeMachineName { get; set; }

        public string Producer { get; set; }

        public List<CoffeeMachineIngredient> CoffeeMachineIngredients { get; set; }

        public List<Drink> Drinks { get; set; }

        public CoffeeMachine()
        {
            Drinks = new List<Drink>();
        }
    }
}
