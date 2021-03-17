using System;

namespace TaskManagerApp.Domain
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public Guid IdUsuario { get; set; }
        public bool TarefaConcluida { get; set; }
    }
}
