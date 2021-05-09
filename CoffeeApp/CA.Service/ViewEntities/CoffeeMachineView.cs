using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Models
{
    public class CoffeeMachineView
    {
        public int Id { get; set; }
        public string CoffeeMachineName { get; set; }
        public string Producer { get; set; }
    }
}
