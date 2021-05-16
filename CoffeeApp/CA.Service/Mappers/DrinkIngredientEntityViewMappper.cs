using CA.Data.Entityes;
using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Mappers
{
    public static class DrinkIngredientEntityViewMappper
    {
        public static DrinkIngredient MapToEntity(this DrinkIngredientView view)
        {
            return new DrinkIngredient()
            {
                Id = view.Id,
                Volume = view.Volume
            };
        }

        public static DrinkIngredientView MapToView(this DrinkIngredient entity)
        {
            return new DrinkIngredientView()
            {
                Id = entity.Id,
                Volume = entity.Volume
            };
        }
    }
}
