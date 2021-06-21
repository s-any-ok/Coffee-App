using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Data.Entityes.Base;

namespace CA.Data.Entityes
{
    public class Order : BaseEntity<int>
    {
        public DateTime OrderDate { get; set; }

        public int CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }

        public int DrinkId { get; set; }

        public Drink Drink { get; set; }

        public Order()
        {
            this.OrderDate = DateTime.UtcNow;
        }
    }
}
