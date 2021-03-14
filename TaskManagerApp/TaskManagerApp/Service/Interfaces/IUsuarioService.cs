using System.Threading.Tasks;
using TaskManagerApp.Domain;

namespace TaskManagerApp.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task CadastrarNovoUsuarioAsync(Usuario usuario);
        bool IndicaDadosCadastroUsuarioPreenchido(Usuario usuario);
    }
}
