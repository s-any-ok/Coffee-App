using System;
using System.ComponentModel.DataAnnotations;

namespace CA.Service.Views
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
