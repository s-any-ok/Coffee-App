using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Entityes
{
    public class CoffeeMachineIngredient
    {
        public int Id { get; set; }

        public bool IsDefault { get; set; }

        public int IngredientTypeId { get; set; }

        public IngredientType IngredientType { get; set; }

        public float Volume { get; set; }

        public int CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }
    }
}
