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
        bool IsCorrectOrder(OrderDTO orderDTO);
        void AddOrder(OrderDTO orderDTO);

        #region NotImplemented

        /*void EditOrder(int id);
        void DeleteOrder(int id);
        IEnumerable<OrderDTO> GetOrdersByDrinkId(int id);
        IEnumerable<OrderDTO> GetAll();
        OrderDTO GetById(int id);*/

        #endregion
    }
}
