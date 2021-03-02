using CoffeeApp.DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeApp.DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<CoffeeMachine> CoffeeMachine { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<DefaultIngredient> DefaultIngredient { get; set; }
        public DbSet<Drink> Drink { get; set; }

        public DbSet<Order> Order { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

    }
    /// For Migrations
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=CoffeeAppDB;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("CoffeeApp.DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
