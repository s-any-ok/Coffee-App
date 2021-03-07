using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Models
{
    public class DrinkDTO
    {
        public Int32 Id { get; set; }

        public string DrinkName { get; set; }

        [Required]
        public Int32 CoffeeMachineId { get; set; }
    }
}
