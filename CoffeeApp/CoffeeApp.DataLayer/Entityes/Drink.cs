using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.DataLayer.Entityes
{
    public class Drink
    {
        public Int32 Id { get; set; }

        public string DrinkName { get; set; }

        public string Producer { get; set; }

        public Int32 CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Order> Orders { get; set; }
    }
}
