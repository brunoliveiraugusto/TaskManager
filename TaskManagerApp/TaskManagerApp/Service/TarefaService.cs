using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Domain;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Service.Interfaces;
using TaskManagerApp.Utils.Exceptions;

namespace TaskManagerApp.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Tarefa> CadastarTarefaAsync(Tarefa tarefa)
        {
            ValidarDadosPreenchidosCadastroTarefa(tarefa);
            return await _tarefaRepository.CriarAsync(tarefa);
        }        

        public void ValidarDadosPreenchidosCadastroTarefa(Tarefa tarefa)
        {
            if(string.IsNullOrEmpty(tarefa.Descricao))
            {
                throw new RequiredFieldException("Por favor, informe a Descrição da tarefa.");
            }
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasCadastradasPorUsuario(Guid usuarioId, bool tarefaConcluida = false)
        {
            return await _tarefaRepository.ObterTarefasPorIdUsuarioAsync(usuarioId, tarefaConcluida);
        }

        public async Task RemoverTarefaAsync(Guid tarefaId, Guid usuarioId)
        {
            await _tarefaRepository.RemoverAsync(tarefaId, usuarioId);
        }

        public async Task AtualizarTarefaAsync(Tarefa tarefa)
        {
            await _tarefaRepository.AtualizarAsync(tarefa);
        }
    }
}
