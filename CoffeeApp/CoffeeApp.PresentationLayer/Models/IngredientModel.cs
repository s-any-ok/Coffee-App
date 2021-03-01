using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.PresentationLayer.Models
{
    public class IngredientViewModel
    {
        public Ingredient Ingredient { get; set; }
    }

    public class IngredientEditModel
    {
        public Int32 Id { get; set; }

        public string IngredientName { get; set; }

        public float Volume { get; set; }

        [Required]
        public Int32 CoffeeMachineId { get; set; }
    }
}
