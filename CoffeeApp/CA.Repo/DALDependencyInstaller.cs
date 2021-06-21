using CA.Data;
using CA.Repo.Implementations;
using CA.Repo.Interfaces;
using CA.Repo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Repo
{
    public static class DalDependencyInstaller
    {
        public static IServiceCollection RegisterDalDependencies(this IServiceCollection services)
        {
            services.AddScoped<EFDBContext, EFDBContext>();

            services.AddScoped<ICoffeeMachineIngredientsRepository, CoffeeMachineIngredientsRepository>();
            services.AddScoped<ICoffeeMachineRepository, CoffeeMachinesRepository>();
            services.AddScoped<IDrinkIngredientsRepository, DrinkIngredientsRepository>();
            services.AddScoped<IDrinkRepository, DrinksRepository>();
            services.AddScoped<IDrinkRepository, DrinksRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}