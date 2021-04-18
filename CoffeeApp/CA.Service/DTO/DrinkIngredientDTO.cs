using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Models
{
    public class DrinkIngredientDTO
    {
        public int Id { get; set; }

        public float Volume { get; set; }

        [Required]
        public int DrinkId { get; set; }

        [Required]
        public int IngredientTypeId { get; set; }
    }
}
