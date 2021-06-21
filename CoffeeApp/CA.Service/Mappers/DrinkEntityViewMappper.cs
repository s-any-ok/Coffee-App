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
    public static class DrinkEntityViewMappper
    {
        public static Drink MapToEntity(this DrinkView view)
        {
            return new Drink()
            {
                Id = view.Id,
                DrinkName = view.DrinkName
            };
        }

        public static DrinkView MapToView(this Drink entity)
        {
            return new DrinkView()
            {
                Id = entity.Id,
                DrinkName = entity.DrinkName
            };
        }
    }
}
