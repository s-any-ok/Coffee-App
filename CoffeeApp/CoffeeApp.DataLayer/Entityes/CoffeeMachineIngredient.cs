using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.DataLayer.Entityes
{
    public class CoffeeMachineIngredient
    {
        public Int32 Id { get; set; }

        public bool isDefault { get; set; }

        public string IngredientName { get; set; }

        public float Volume { get; set; }

        public Int32 CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }
    }
}
