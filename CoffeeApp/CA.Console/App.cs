using CA.Data;
using CA.Repo;
using CA.Service;
using CoffeeApp.Console.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeApp.Console
{
    class App
    {
        
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
         
        private void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDalDependencies();
            services.RegisterBLLDependencies();
            services.RegisterCMDDependencies();
        }
        
        public void Run()
        {
            IUserInterface consoleMenu = serviceProvider.GetRequiredService<IUserInterface>();
            consoleMenu.Show();
        }
        
    }
}