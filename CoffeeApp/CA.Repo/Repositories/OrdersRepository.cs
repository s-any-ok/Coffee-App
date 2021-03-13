using CA.Repo.Interfaces;
using CA.Data;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CA.Repo.Implementations
{
    public class OrdersRepository : IRepository<Order>
    {
        private EFDBContext context;
        public OrdersRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAll()
        {
                return context.Order;
        }

        public IEnumerable<Order> GetAll(int id)
        {
            return context.Order.Where(o => o.DrinkId == id);
        }

        public Order GetById(int orderId)
        {
                return context.Order.FirstOrDefault(x => x.Id == orderId);
        }

        public void Update(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        public void Create(Order order)
        {
            if (order.Id == 0)
                context.Order.Add(order);
            else
                context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(Order order)
        {
            context.Order.Remove(order);
        }
    }
}
