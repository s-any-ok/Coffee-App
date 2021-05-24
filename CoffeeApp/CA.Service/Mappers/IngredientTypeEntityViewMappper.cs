using CA.Data.Entityes;
using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Mappers
{
    public static class IngredientTypeEntityViewMappper
    {
        public static IngredientType MapToEntity(this IngredientTypeView view)
        {
            return new IngredientType()
            {
                Id = view.Id,
                IngredientName = view.IngredientName
            };
        }

        public static IngredientTypeView MapToView(this IngredientType entity)
        {
            return new IngredientTypeView()
            {
                Id = entity.Id,
                IngredientName = entity.IngredientName
            };
        }
    }
}
