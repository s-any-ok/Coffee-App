using System.Collections.Generic;
using CA.Data.Entityes;

namespace CA.Repo.Interfaces
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetAllByDrinkId(int id);
    }
}