using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Models
{
    public class CoffeeMachineViewModel
    {
        public CoffeeMachine CoffeeMachine { get; set; }
        public List<CoffeeMachineIngredientViewModel> Ingredients { get; set; }
        public List<DrinkViewModel> Drinks { get; set; }
    }

    public class CoffeeMachineEditModel
    {
        public Int32 Id { get; set; }
        public string CoffeeMachineName { get; set; }
        public string Producer { get; set; }
    }
}
