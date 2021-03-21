using Bogus;
using System;
using System.Collections.Generic;
using TaskManagerApp.Domain;

namespace TaskManagerAppTest.DomainTest
{
    public class TarefaTestBuilder
    {
        protected Tarefa Model;
        protected List<Tarefa> Models;

        public TarefaTestBuilder()
        {
            Model = new Tarefa();
            Models = new List<Tarefa>();
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

        public TarefaTestBuilder DefaultList()
        {
            Models.Add( new Tarefa {
                    DataCriacao = DateTime.Now.AddDays(-5),
                    Descricao = new Faker().Lorem.Words(5).ToString(),
                    Id = Guid.NewGuid(),
                    IdUsuario = Guid.NewGuid(),
                    TarefaConcluida = true 
            });

            Models.Add( new Tarefa {
                    DataCriacao = DateTime.Now.AddMonths(-3),
                    Descricao = new Faker().Lorem.Words(6).ToString(),
                    Id = Guid.NewGuid(),
                    IdUsuario = Guid.NewGuid(),
                    TarefaConcluida = false
            });

            Models.Add( new Tarefa {
                    DataCriacao = DateTime.Now.AddDays(-8),
                    Descricao = new Faker().Lorem.Words(7).ToString(),
                    Id = Guid.NewGuid(),
                    IdUsuario = Guid.NewGuid(),
                    TarefaConcluida = false
            });
            
            return this;
        }

        public Guid DefaultGuid()
        {
            return Guid.NewGuid();
        }

        public bool DefaultBoolean()
        {
            return true;
        }

        public Tarefa Build()
        {
            return Model;
        }

        public List<Tarefa> BuildList()
        {
            return Models;
        }
    }
}
