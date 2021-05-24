﻿using CA.Data.Entityes;
using System.ComponentModel.DataAnnotations;

namespace CA.Service.Models
{
    public class CoffeeMachineIngredientView
    {
        public int Id { get; set; }

        public IngredientTypeView IngredientType { get; set; }
        public float MaxVolume { get; set; }
        public float Volume { get; set; }

        public float Fulfilment { get; set; }

        [Required]
        public int CoffeeMachineId { get; set; }

        [Required]
        public int IngredientTypeId { get; set; }
    }
}
