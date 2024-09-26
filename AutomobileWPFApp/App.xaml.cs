using AutomobileLibrary.Repository;
using AutomobileLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AutomobileWPFApp {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private IServiceProvider serviceProvider;
        public App() {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services) {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string repositoryType = config["repository"];

            services.AddSingleton<ICarRepository>(provider => CarRepositoryFactory.CreateRepository(repositoryType));
            services.AddSingleton<CarViewModel>();
            services.AddSingleton<WindowCarManagement>();
        }

        private void OnStartUp(object sender, EventArgs e) {
            var windowCarManagement = serviceProvider.GetService<WindowCarManagement>();
            //var newWindow = new WindowCarManagement(serviceProvider.GetService<ICarRepository>());
            windowCarManagement.Show();
        }

    }

}
