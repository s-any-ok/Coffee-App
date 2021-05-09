using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Models
{
    public class OrderView
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public int DrinkId { get; set; }
        [Required]
        public int CoffeeMachineId { get; set; }
    }
}
