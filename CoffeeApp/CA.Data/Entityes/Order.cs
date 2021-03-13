using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Entityes
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int DrinkId { get; set; }

        public Drink Drink { get; set; }

        public Order()
        {
            this.OrderDate = DateTime.UtcNow;
        }
    }
}
