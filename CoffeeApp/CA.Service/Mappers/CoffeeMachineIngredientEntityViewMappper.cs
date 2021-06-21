using CA.Data.Entityes;
using CA.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Service.Views;

namespace CA.Service.Mappers
{
    public static class CoffeeMachineIngredientEntityViewMappper
    {
        public static CoffeeMachineIngredient MapToEntity(this CoffeeMachineIngredientView view)
        {
            return new CoffeeMachineIngredient()
            {
                Id = view.Id,
                Volume = view.Volume,
                MaxVolume = view.MaxVolume,
                IngredientTypeId = view.IngredientTypeId,
                CoffeeMachineId = view.CoffeeMachineId
            };
        }

        public static CoffeeMachineIngredientView MapToView(this CoffeeMachineIngredient entity)
        {
            return new CoffeeMachineIngredientView()
            {
                Id = entity.Id,
                Volume = entity.Volume,
                MaxVolume = entity.MaxVolume,
                Fulfilment = GetFulfilment(entity.Volume, entity.MaxVolume),
                IngredientType = IngredientTypeEntityViewMappper.MapToView(entity.IngredientType)
            };
        }
        private static float GetFulfilment(float currentValue, float maxValue) => (100f * currentValue) / maxValue;
    }
}
