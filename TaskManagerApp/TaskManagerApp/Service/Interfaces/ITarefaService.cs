using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Domain;

namespace TaskManagerApp.Service.Interfaces
{
    public interface ITarefaService
    {
        Task CadastarTarefaAsync(Tarefa tarefa);
        void ValidarDadosPreenchidosCadastroTarefa(Tarefa tarefa);
    }
}
