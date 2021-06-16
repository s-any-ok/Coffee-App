using CA.Repo;
using CA.Repo.Implementations;
using CA.Repo.Interfaces;
using CA.Repo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Data
{
    public static class DALDependencyInstaller
    {
        public static IServiceCollection RegisterDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<EFDBContext, EFDBContext>();

            services.AddScoped<ICoffeeMachineIngredientsRepository, CoffeeMachineIngredientsRepository>();
            services.AddScoped<ICoffeeMachineRepository, CoffeeMachinesRepository>();
            services.AddScoped<IDrinkIngredientsRepository, DrinkIngredientsRepository>();
            services.AddScoped<IDrinkRepository, DrinksRepository>();
            services.AddScoped<IIngredientTypesRepository, IngredientTypesRepository>();
            services.AddScoped<IDrinkRepository, DrinksRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}