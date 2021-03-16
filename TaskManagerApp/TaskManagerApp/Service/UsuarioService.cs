using System;
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

        public async Task<Guid> CadastrarNovoUsuarioAsync(Usuario usuario)
        {
            _fileRepository.CreateDirectory(DataFile.Usuario);
            ValidarDadosCadastroUsuarioPreenchido(usuario);
            return await _usuarioRepository.CriarUsuarioAsync(usuario);
            

        }

        public bool ValidarDadosCadastroUsuarioPreenchido(Usuario usuario)
        {
            if(string.IsNullOrEmpty(usuario.Login))
            {
                throw new RequiredFieldException("Por favor, informe o Login do usuário.");
            }

            if (string.IsNullOrEmpty(usuario.Password))
            {
                throw new RequiredFieldException("Por favor, informe a Senha do usuário.");
            }

            return true;
        }
    }
}
