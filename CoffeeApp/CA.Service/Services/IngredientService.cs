using CA.Repo;
using CA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Services
{
    public class IngredientService : IIngredientService
    {
        private UnitOfWork _unitOfWork;
        public IngredientService()
        {
            this._unitOfWork = new UnitOfWork();
        }

        public string GetIngredientNameByTypeId(int id) =>_unitOfWork.IngredientType.GetById(id).IngredientName;
    }
}
