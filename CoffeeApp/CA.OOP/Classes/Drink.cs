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

        public int CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }

        public List<DrinkIngredient> DrinkIngredients { get; set; }
    }
}
