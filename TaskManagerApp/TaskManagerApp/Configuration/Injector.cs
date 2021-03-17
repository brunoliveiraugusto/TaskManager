using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using TaskManagerApp.Repository;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Service;
using TaskManagerApp.Service.Interfaces;
using TaskManagerApp.View;

namespace TaskManagerApp.Configuration
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITarefaService, TarefaService>();
            #endregion

            #region Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            #endregion

            #region View
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(LoginWindow));
            services.AddTransient(typeof(HomeWindow));
            #endregion

            #region IO
            services.AddSingleton<IFileSystem>(new FileSystem());
            #endregion
        }
    }
}
