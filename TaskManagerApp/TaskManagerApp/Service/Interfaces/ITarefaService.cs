using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Domain;

namespace TaskManagerApp.Service.Interfaces
{
    public interface ITarefaService
    {
        Task<Tarefa> CadastarTarefaAsync(Tarefa tarefa);
        void ValidarDadosPreenchidosCadastroTarefa(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> ObterTarefasCadastradasPorUsuario(Guid usuarioId, bool tarefaConcluida = false);
        Task RemoverTarefaAsync(Guid tarefaId, Guid usuarioId);
        Task AtualizarTarefaAsync(Tarefa tarefa);
    }
}
