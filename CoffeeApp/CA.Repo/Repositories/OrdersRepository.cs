using CA.Repo.Interfaces;
using CA.Data;
using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CA.Repo.Repositories;

namespace CA.Repo.Implementations
{
    public class OrdersRepository : Repository<Order, int>, IOrdersRepository
    {

        public OrdersRepository(EFDBContext _context) : base(_context) { }

        public IEnumerable<Order> GetAllBCoffeeMachineId(int id)
        {
            return _context.Order.Where(o => o.CoffeeMachineId == id).AsNoTracking();
        }
        
        public IEnumerable<Order> GetAllByDrinkId(int id)
        {
            return _context.Order.Where(o => o.DrinkId == id).AsNoTracking();
        }

        public Order GetFirstOrder(int coffeeMachineId)
        {
            return _context.Order.FirstOrDefault(x => x.CoffeeMachineId == coffeeMachineId);
        }

        public Order GetLastOrder(int coffeeMachineId)
        {
            return _context.Order.OrderByDescending(o => o.Id).FirstOrDefault(x => x.CoffeeMachineId == coffeeMachineId);
        }
    }
}
