using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Data.Entityes.Base;

namespace CA.Data.Entityes
{
    public class IngredientType : BaseEntity<int>
    {
        public string IngredientName { get; set; }
    }
}
