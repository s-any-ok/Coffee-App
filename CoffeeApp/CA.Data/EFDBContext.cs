using CA.Data.Entityes;
using System.Data.Entity;

namespace CA.Data
{
    public class EFDBContext : DbContext
    {
        public EFDBContext() : base(@"Data Source=. ; Initial Catalog=CoffeeAppDB; Integrated Security=true") { }
        public DbSet<CoffeeMachine> CoffeeMachine { get; set; }
        public DbSet<DrinkIngredient> DrinkIngredient { get; set; }
        public DbSet<CoffeeMachineIngredient> CoffeeMachineIngredient { get; set; }
        public DbSet<Drink> Drink { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
