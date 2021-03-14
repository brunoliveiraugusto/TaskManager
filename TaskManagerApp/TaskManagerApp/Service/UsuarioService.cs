using System.Threading.Tasks;
using TaskManagerApp.Domain;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Service.Interfaces;
using TaskManagerApp.Utils.Enum;
using TaskManagerApp.Utils.Exceptions;

namespace TaskManagerApp.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IFileRepository _fileRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IFileRepository fileRepository)
        {
            _usuarioRepository = usuarioRepository;
            _fileRepository = fileRepository;
        }

        public async Task CadastrarNovoUsuarioAsync(Usuario usuario)
        {
            _fileRepository.CreateDirectory(DataFile.Usuario);
            if(IndicaDadosCadastroUsuarioPreenchido(usuario))
            {
                await _usuarioRepository.CriarUsuarioAsync(usuario);
            }

        }

        public bool IndicaDadosCadastroUsuarioPreenchido(Usuario usuario)
        {
            if(string.IsNullOrEmpty(usuario.Login))
            {
                throw new RequiredFieldException("O campo Login é obrigatório.");
            }

            if (string.IsNullOrEmpty(usuario.Password))
            {
                throw new RequiredFieldException("O campo Password é obrigatório.");
            }

            return true;
        }
    }
}
