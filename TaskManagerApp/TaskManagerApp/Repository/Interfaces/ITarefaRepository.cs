using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Domain;

namespace TaskManagerApp.Repository.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task CriarAsync(Tarefa tarefa);
        Task RemoverAsync(Guid id, Guid idUsuario);
        Task AtualizarAsync(Tarefa tarefa);
        List<Tarefa> ObterTarefas();
        Task<List<Tarefa>> ObterTarefasPorIdUsuarioAsync(Guid usuarioId);
    }
}
