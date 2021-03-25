using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.Data.Entityes
{
    public class CoffeeMachine
    {
        public int Id { get; set; }

        public string CoffeeMachineName { get; set; }

        public string Producer { get; set; }

        public List<Ingredient> DefaultIngredients { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}
