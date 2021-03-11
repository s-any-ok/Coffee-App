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
        IEnumerable<OrderDTO> GetAll();
        OrderDTO GetById(int id);
        void AddOrder(OrderDTO orderDTO);
        void EditOrder(int id);
        void DeleteOrder(int id);
    }
}
