using System;
using System.Threading.Tasks;
using TaskManagerApp.Domain;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Service.Interfaces;
using TaskManagerApp.Utils.Exceptions;

namespace TaskManagerApp.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid> LoginAsync(Usuario usuario)
        {
            ValidarDadosLogin(usuario);
            return await _usuarioRepository.Login(usuario);
        }

        public void ValidarDadosLogin(Usuario usuario)
        {
            if(string.IsNullOrEmpty(usuario.Login))
            {
                throw new RequiredFieldException("Por favor, informe o Login do usuário.");
            }

            if (string.IsNullOrEmpty(usuario.Password))
            {
                throw new RequiredFieldException("Por favor, informe a Senha do usuário.");
            }
        }
    }
}
