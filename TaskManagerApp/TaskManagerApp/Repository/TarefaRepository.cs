using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerApp.Domain;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Utils.Enum;

namespace TaskManagerApp.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private IFileRepository _fileRepository;
        private IFileSystem _fileSystem;
        private readonly string _sourcePath;

        private List<Tarefa> Tarefas { get; set; }

        public TarefaRepository(IFileRepository fileRepository, IFileSystem fileSystem)
        {
            _fileRepository = fileRepository;
            _fileSystem = fileSystem;
            _sourcePath = _fileRepository.GetSourcePath(DataFile.Tarefa);
            Tarefas = ObterTarefas();
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            int index = Tarefas.IndexOf(tarefa);
            Tarefas[index] = tarefa;
            await _fileRepository.ClearFileAsync(_sourcePath);
            await PersistirAsync(Serialize(Tarefas));
        }

        public async Task CriarAsync(Tarefa tarefa)
        {
            _fileRepository.CreateDirectory(DataFile.Tarefa);
            tarefa.Id = GetNewGuid();
            if (Tarefas == null) Tarefas = new List<Tarefa>();
            Tarefas.Add(tarefa);
            await _fileRepository.ClearFileAsync(_sourcePath);
            await PersistirAsync(Serialize(Tarefas));
        }

        public List<Tarefa> ObterTarefas()
        {
            if (_fileRepository.DirectoryExists(DataFile.Tarefa))
                return JsonConvert.DeserializeObject<List<Tarefa>>(_fileSystem.File.ReadAllText(_sourcePath));
            else
                return null;
        }

        public async Task RemoverAsync(Guid id, Guid idUsuario)
        {
            Tarefas.RemoveAll(tarefa => tarefa.Id == id && tarefa.IdUsuario == idUsuario);
            await _fileRepository.ClearFileAsync(_sourcePath);
            await PersistirAsync(Serialize(Tarefas));
        }

        public async Task PersistirAsync(string tarefas)
        {
            await _fileSystem.File.AppendAllTextAsync(_sourcePath, tarefas);
        }

        public string Serialize(List<Tarefa> tarefas)
        {
            return JsonConvert.SerializeObject(tarefas);
        }

        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }

        public async Task<List<Tarefa>> ObterTarefasPorIdUsuarioAsync(Guid usuarioId)
        {
            var tarefas = JsonConvert.DeserializeObject<IEnumerable<Tarefa>>(await _fileSystem.File.ReadAllTextAsync(_sourcePath));
            return tarefas.Where(tarefa => tarefa.IdUsuario == usuarioId).ToList();
        }
    }
}
