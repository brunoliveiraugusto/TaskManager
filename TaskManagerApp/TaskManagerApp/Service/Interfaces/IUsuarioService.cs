using System;
using System.Threading.Tasks;
using TaskManagerApp.Domain;

namespace TaskManagerApp.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<Guid> CadastrarNovoUsuarioAsync(Usuario usuario);
        void ValidarDadosPreenchidosCadastroUsuario(Usuario usuario);
    }
}
