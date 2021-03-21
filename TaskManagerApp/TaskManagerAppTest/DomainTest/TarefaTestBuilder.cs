using Bogus;
using System;
using TaskManagerApp.Domain;

namespace TaskManagerAppTest.DomainTest
{
    public class TarefaTestBuilder
    {
        protected Tarefa Model;

        public TarefaTestBuilder()
        {
            Model = new Tarefa();
        }

        public TarefaTestBuilder Default()
        {
            Model.DataCriacao = DateTime.Now;
            Model.Descricao = new Faker().Lorem.Words(5).ToString();
            Model.Id = Guid.NewGuid();
            Model.IdUsuario = Guid.NewGuid();
            Model.TarefaConcluida = false;

            return this;
        }

        public Tarefa Build()
        {
            return Model;
        }
    }
}
