using CA.Service;
using CA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Console.Controllers
{
    public class OrderController
    {
        IServicesManager servicesManager;
        public OrderController(IServicesManager serv)
        {
            servicesManager = serv;
        }
        
    }
}
