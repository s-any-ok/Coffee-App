using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.PresentationLayer.Models
{
    public class DrinkViewModel
    {
        public Drink Drink { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }
    }

    public class DrinkEditModel
    {
        public Int32 Id { get; set; }

        public string DrinkName { get; set; }

        [Required]
        public Int32 CoffeeMachineId { get; set; }
    }
}
