using System.Windows;
using CA.Data;
using CA.Service;
using CA.WPF.View;
using CA.WPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace CA.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
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
            services.RegisterDALDependencies();
            services.RegisterBLLDependencies();
            
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<OrderViewModel>();
            services.AddSingleton<TimeToRechargeViewModel>();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
