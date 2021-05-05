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

                var i1 = new IngredientType() { IngredientName = "Milk" };
                var i2 = new IngredientType() { IngredientName = "Water" };
                var i3 = new IngredientType() { IngredientName = "Coffee" };
                var i4 = new IngredientType() { IngredientName = "Sugar" };

                var c1 = new CoffeeMachine() { CoffeeMachineName = "Toshiba", Producer = "China" };
                var c2 = new CoffeeMachine() { CoffeeMachineName = "LG", Producer = "Germany" };

                context.CoffeeMachine.Add(c1);
                context.CoffeeMachine.Add(c2);
                context.SaveChanges();

                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient() {
                    MaxVolume = 1f,
                    IngredientType = i1,
                    Volume = 1f,
                    CoffeeMachine = c1
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    MaxVolume = 1.5f,
                    IngredientType = i2,
                    Volume = 1.5f,
                    CoffeeMachine = c1
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    MaxVolume = 1f,
                    IngredientType = i3,
                    Volume = 1f,
                    CoffeeMachine = c1
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    MaxVolume = 0.5f,
                    IngredientType = i4,
                    Volume = 0.5f,
                    CoffeeMachine = c1
                }
                );
                
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    MaxVolume = 1.21f,
                    IngredientType = i1,
                    Volume = 1.21f,
                    CoffeeMachine = c2
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    MaxVolume = 1.8f,
                    IngredientType = i2,
                    Volume = 1.8f,
                    CoffeeMachine = c2
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    MaxVolume = 1.3f,
                    IngredientType = i3,
                    Volume = 1.3f,
                    CoffeeMachine = c2
                }
                );
                context.CoffeeMachineIngredient.Add(new CoffeeMachineIngredient()
                {
                    MaxVolume = 0.6f,
                    IngredientType = i4,
                    Volume = 0.6f,
                    CoffeeMachine = c2
                }
                );

                context.SaveChanges();

                var d1 = new Drink() { DrinkName = "Americano"};
                var d2 = new Drink() { DrinkName = "Latte" }; ;
                context.Drink.AddRange(new List<Drink> { d1, d2 });

                //context.Drink.Add(d1);
                //context.Drink.Add(d2);
                context.SaveChanges();

                c1.Drinks.Add(d1);

                c2.Drinks.Add(d1);
                c2.Drinks.Add(d2);

                context.DrinkIngredient.Add(new DrinkIngredient()
                {
                    IngredientType = i3,
                    Volume = 0.2f,
                    Drink = d1
                }
                );

                context.DrinkIngredient.Add(new DrinkIngredient()
                {
                    IngredientType = i3,
                    Volume = 0.2f,
                    Drink = d2
                }
                );
                context.DrinkIngredient.Add(new DrinkIngredient()
                {
                    IngredientType = i1,
                    Volume = 0.2f,
                    Drink = d2
                }
                );
                context.SaveChanges();
            }
        }

    }
}
