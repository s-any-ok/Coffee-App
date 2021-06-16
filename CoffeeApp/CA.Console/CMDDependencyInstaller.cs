using System.Data;
using CA.Console.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeApp.Console
{
    public static class CMDDependencyInstaller
    {
        public static IServiceCollection RegisterCMDDependencies(this IServiceCollection services)
        {
            services.AddSingleton(typeof(DrinkConsoleWriter), typeof(DrinkConsoleWriter));
            services.AddSingleton(typeof(CoffeeMachineConsoleWriter), typeof(CoffeeMachineConsoleWriter));
            services.AddSingleton(typeof(OrderConsoleWriter), typeof(OrderConsoleWriter));
            return services;
        }
    }
}