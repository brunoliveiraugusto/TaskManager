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

        public async Task CadastarTarefaAsync(Tarefa tarefa)
        {
            ValidarDadosPreenchidosCadastroTarefa(tarefa);
            await _tarefaRepository.CriarAsync(tarefa);
        }        

        public void ValidarDadosPreenchidosCadastroTarefa(Tarefa tarefa)
        {
            if(string.IsNullOrEmpty(tarefa.Descricao))
            {
                throw new RequiredFieldException("Por favor, informe a Descrição da tarefa.");
            }
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasCadastradasPorUsuario(Guid usuarioId)
        {
            return await _tarefaRepository.ObterTarefasPorIdUsuarioAsync(usuarioId);
        }

        public async Task RemoverTarefaAsync(Guid tarefaId, Guid usuarioId)
        {
            await _tarefaRepository.RemoverAsync(tarefaId, usuarioId);
        }
    }
}
