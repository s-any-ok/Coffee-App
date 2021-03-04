using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.DataLayer
{
   public static class StartData
    {
        public static void InitData(EFDBContext context) {
            if (!context.CoffeeMachine.Any()) {
                context.CoffeeMachine.Add(new CoffeeMachine() { CoffeeMachineName = "Tosiba", Producer = "China" });
                context.CoffeeMachine.Add(new CoffeeMachine() { CoffeeMachineName = "LG", Producer = "Germany" });
                context.SaveChanges();

                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient() {
                    isDefault = false,
                    IngredientName = "Milk",
                    Volume = 1.2f,
                    CoffeeMachineId = context.CoffeeMachine.First().Id
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = false,
                    IngredientName = "Milk",
                    Volume = 1.2f,
                    CoffeeMachineId = context.CoffeeMachine.First().Id
                }
                );
                context.SaveChanges();
            }
        }
    }
}
