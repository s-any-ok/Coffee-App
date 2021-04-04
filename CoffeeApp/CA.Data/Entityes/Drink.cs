using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Entityes
{
    public class Drink
    {
        public int Id { get; set; }

        public string DrinkName { get; set; }

        public List<DrinkIngredient> DrinkIngredients { get; set; }

        public List<CoffeeMachine> CoffeeMachines { get; set; }

        public Drink()
        {
            CoffeeMachines = new List<CoffeeMachine>();
        }
    }
}
