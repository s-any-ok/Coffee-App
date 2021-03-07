using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Models
{
    public class CoffeeMachineIngredientDTO
    {
        public Int32 Id { get; set; }

        public bool isDefault { get; set; }

        public string IngredientName { get; set; }

        public float Volume { get; set; }

        [Required]
        public Int32 CoffeeMachineId { get; set; }
    }
}
