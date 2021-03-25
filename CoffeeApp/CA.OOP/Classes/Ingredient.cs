﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Entityes
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string IngredientName { get; set; }

        public float Volume { get; set; }

        public int CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }
    }
}