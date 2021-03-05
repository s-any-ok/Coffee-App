using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Data.Entityes
{
    public class DrinkIngredient
    {
        public Int32 Id { get; set; }

        public string IngredientName { get; set; }

        public float Volume { get; set; }

        public Int32 DrinkId { get; set; }

        public Drink Drink { get; set; }
    }
}
