using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskManagerApp.Repository;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Service;
using TaskManagerApp.Service.Interfaces;

namespace TaskManagerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();

            //Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            
            services.AddSingleton<IFileSystem>(new FileSystem());

            services.AddTransient(typeof(MainWindow));
        }
    }
}
