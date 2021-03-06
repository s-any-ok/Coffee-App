﻿using CoffeeApp.Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Service.Models
{
    public class DrinkViewModelTest
    {
        public Drink Drink { get; set; }

        //public List<IngredientViewModel> Ingredients { get; set; }
    }

    public class DrinkEditModelTest
    {
        public Int32 Id { get; set; }

        public string DrinkName { get; set; }

        [Required]
        public Int32 CoffeeMachineId { get; set; }
    }
}
