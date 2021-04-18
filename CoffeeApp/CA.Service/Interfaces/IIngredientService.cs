using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Interfaces
{
    public interface IIngredientService
    {
        string GetIngredientNameByTypeId(int id);
    }
}
