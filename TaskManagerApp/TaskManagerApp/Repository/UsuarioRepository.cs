using System.IO.Abstractions;
using TaskManagerApp.Domain;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Utils.Enum;
using Newtonsoft.Json;
using TaskManagerApp.Utils.Exceptions;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace TaskManagerApp.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IFileRepository _fileRepository;
        private IFileSystem _fileSystem;
        private readonly string _sourcePath;
        private List<Usuario> Usuarios { get; set; }

        public UsuarioRepository(IFileRepository fileRepository, IFileSystem fileSystem)
        {
            _fileRepository = fileRepository;
            _fileSystem = fileSystem;
            _sourcePath = _fileRepository.GetSourcePath(DataFile.Usuario);
        }

        public async Task<Guid> CriarUsuarioAsync(Usuario usuario)
        {
            bool usuarioCadastrado = await IndicaUsuarioExistenteAsync(usuario.Login);
            
            if (!usuarioCadastrado)
            {
                if (Usuarios == null) Usuarios = new List<Usuario>();
                usuario.Id = GetNewGuid();
                Usuarios.Add(usuario);
                await _fileRepository.ClearFileAsync(_sourcePath);
                await PersistirAsync(Serialize(Usuarios));
                return usuario.Id;
            }
            else
            {
                throw new UserExistsException();
            }
        }

        public async Task<bool> IndicaUsuarioExistenteAsync(string username)
        {
            Usuarios = await ObterUsuariosAsync();
            return Usuarios != null ? Usuarios.Any(x => x.Login.Equals(username)) : false;
        }

        private async Task<List<Usuario>> ObterUsuariosAsync()
        {
            return JsonConvert.DeserializeObject<List<Usuario>>(await _fileSystem.File.ReadAllTextAsync(_sourcePath));
        }

        public async Task<Guid> Login(Usuario loginUsuario)
        {
            Usuarios = await ObterUsuariosAsync();
            if (Usuarios == null) throw new UserNotFoundException();

            var user = Usuarios.Where(usuario => usuario.Login == loginUsuario.Login.ToLower()
                && usuario.Password == loginUsuario.Password.ToLower())
                .FirstOrDefault();

            if (user != null) 
            {
                return user.Id;
            } 
            else
            {
                throw new UserNotFoundException();
            }
        }

        public string Serialize(List<Usuario> usuarios)
        {
            return JsonConvert.SerializeObject(usuarios);
        }

        public async Task PersistirAsync(string usuarios)
        {
            await _fileSystem.File.AppendAllTextAsync(_sourcePath, usuarios);
        }

        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
