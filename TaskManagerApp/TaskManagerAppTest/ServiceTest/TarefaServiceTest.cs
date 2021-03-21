﻿using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Domain;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Service;
using TaskManagerAppTest.DomainTest;
using TaskManagerAppTest.RepositoryTest;
using Xunit;

namespace TaskManagerAppTest.ServiceTest
{
    public class TarefaServiceTest
    {
        private Mock<ITarefaRepository> _tarefaRepositoryMock = new TarefaRepositoryTestBuilder().Build();

        private TarefaService MontarConstrutor()
        {
            return new TarefaService(_tarefaRepositoryMock.Object);
        }

        [Fact(DisplayName = "Gravação de uma nova tarefa")]
        async public void GravarTarefaTest()
        {
            #region Given
            TarefaService service = MontarConstrutor();
            #endregion

            #region When
            _tarefaRepositoryMock.Setup(s => s.CriarAsync(It.IsAny<Tarefa>())).Returns(Task.FromResult(new TarefaTestBuilder().Default().Build()));
            var result = await service.CadastarTarefaAsync(new TarefaTestBuilder().Default().Build());
            #endregion

            #region
            result.Should().NotBeNull();
            #endregion
        }
    }
}
