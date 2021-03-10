using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data
{
   public static class StartData
    {
        public static void InitData(EFDBContext context) {
            if (true) {

                var c1 = new CoffeeMachine() { CoffeeMachineName = "Toshiba", Producer = "China" };
                var c2 = new CoffeeMachine() { CoffeeMachineName = "LG", Producer = "Germany" };

                context.CoffeeMachine.Add(c1);
                context.CoffeeMachine.Add(c2);
                context.SaveChanges();

                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient() {
                    isDefault = true,
                    IngredientName = "Milk",
                    Volume = 1f,
                    CoffeeMachine = c1
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = true,
                    IngredientName = "Water",
                    Volume = 1.5f,
                    CoffeeMachine = c1
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = true,
                    IngredientName = "Coffee",
                    Volume = 1f,
                    CoffeeMachine = c1
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = true,
                    IngredientName = "Sugar",
                    Volume = 0.5f,
                    CoffeeMachine = c1
                }
                );



                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = true,
                    IngredientName = "Milk",
                    Volume = 1.21f,
                    CoffeeMachine = c2
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = true,
                    IngredientName = "Water",
                    Volume = 1.8f,
                    CoffeeMachine = c2
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = true,
                    IngredientName = "Coffee",
                    Volume = 1.3f,
                    CoffeeMachine = c2
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    isDefault = true,
                    IngredientName = "Sugar",
                    Volume = 0.6f,
                    CoffeeMachine = c2
                }
                );
                context.SaveChanges();
            }
        }

    }
}
