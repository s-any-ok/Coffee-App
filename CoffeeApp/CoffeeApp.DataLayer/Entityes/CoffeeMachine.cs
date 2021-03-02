using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApp.DataLayer.Entityes
{
    public class CoffeeMachine
    {
        public Int32 Id { get; set; }

        public string CoffeeMachineName { get; set; }

        public string Producer { get; set; }

        public List<DefaultIngredient> DefaultIngredients { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}
