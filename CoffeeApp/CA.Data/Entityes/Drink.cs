using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Data.Entityes.Base;

namespace CA.Data.Entityes
{
    public class Drink : BaseEntity<int>
    {
        public string DrinkName { get; set; }

        public List<DrinkIngredient> DrinkIngredients { get; set; }

        public List<CoffeeMachine> CoffeeMachines { get; set; }

        public Drink()
        {
            CoffeeMachines = new List<CoffeeMachine>();
        }
    }
}
