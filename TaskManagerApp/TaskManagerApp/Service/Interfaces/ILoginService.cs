using System;
using System.Threading.Tasks;
using TaskManagerApp.Domain;

namespace TaskManagerApp.Service.Interfaces
{
    public interface ILoginService
    {
        Task<Guid> LoginAsync(Usuario usuario);
        void ValidarDadosLogin(Usuario usuario);
    }
}
