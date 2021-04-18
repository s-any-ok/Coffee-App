﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Entityes
{
    public class DrinkIngredient
    {
        public int Id { get; set; }

        public int IngredientTypeId { get; set; }
        public IngredientType IngredientType { get; set; }

        public float Volume { get; set; }

        public int DrinkId { get; set; }

        public Drink Drink { get; set; }
    }
}
