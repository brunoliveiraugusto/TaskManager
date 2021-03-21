using Moq;
using TaskManagerApp.Repository.Interfaces;

namespace TaskManagerAppTest.RepositoryTest
{
    public class TarefaRepositoryTestBuilder
    {
        protected Mock<ITarefaRepository> Model;

        public TarefaRepositoryTestBuilder()
        {
            Model = new Mock<ITarefaRepository>();
        }

        public Mock<ITarefaRepository> Build()
        {
            return Model;
        }
    }
}
