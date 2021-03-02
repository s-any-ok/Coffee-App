using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.DataLayer.Entityes
{
    public class Order
    {
        public Int32 Id { get; set; }

        public Int32 DrinkId { get; set; }

        public Drink Drink { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
