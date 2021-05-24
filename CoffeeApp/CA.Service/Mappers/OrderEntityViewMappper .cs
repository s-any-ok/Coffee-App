using CA.Data.Entityes;
using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Mappers
{
    public static class OrderEntityViewMappper
    {
        public static Order MapToEntity(this OrderView view)
        {
            return new Order()
            {
                DrinkId = view.DrinkId,
                CoffeeMachineId = view.CoffeeMachineId
            };
        }

        public static OrderView MapToView(this Order entity)
        {
            return new OrderView()
            {
                Id = entity.Id,
                DrinkId = entity.DrinkId,
                OrderDate = entity.OrderDate,
                CoffeeMachineId = entity.CoffeeMachineId
            };
        }
    }
}
