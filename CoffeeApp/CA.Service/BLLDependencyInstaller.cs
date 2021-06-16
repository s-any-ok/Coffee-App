using CA.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Service
{
    public static class BLLDependencyInstaller
    {
        public static IServiceCollection RegisterBLLDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ICoffeeMachineService, CoffeeMachineService>();
            services.AddSingleton<IDrinkService, DrinkService>();
            services.AddSingleton<IOrderService, OrderService>();
            return services;
        }
    }
}