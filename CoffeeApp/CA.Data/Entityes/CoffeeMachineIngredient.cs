using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Data.Entityes.Base;

namespace CA.Data.Entityes
{
    public class CoffeeMachineIngredient : BaseEntity<int>
    {
        public int IngredientTypeId { get; set; }

        public IngredientType IngredientType { get; set; }

        public float Volume { get; set; }
        
        public float MaxVolume { get; set; }

        public int CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }
    }
}
