using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service
{
    public interface IOrderService
    {
        bool IsCorrectOrder(OrderView order);
        void AddOrder(OrderView order);

        DateTime GetLastOrderDate(int id);

        DateTime GetFirstOrderDate(int id);

        #region NotImplemented

        /*void EditOrder(int id);
        void DeleteOrder(int id);
        IEnumerable<OrderDTO> GetOrdersByDrinkId(int id);
        IEnumerable<OrderDTO> GetAll();
        OrderDTO GetById(int id);*/

        #endregion
    }
}
