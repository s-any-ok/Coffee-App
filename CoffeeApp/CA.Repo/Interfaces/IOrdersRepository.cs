using System;
using System.Collections.Generic;
using CA.Data.Entityes;

namespace CA.Repo.Interfaces
{
    public interface IOrdersRepository : IRepository<Order>
    {
        IEnumerable<Order> GetAllBCoffeeMachineId(int id);
        IEnumerable<Order> GetAllByDrinkId(int id);
        Order GetFirstOrder(int coffeeMachineId);
        Order GetLastOrder(int coffeeMachineId);
    }
}