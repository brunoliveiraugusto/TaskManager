using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagerApp.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        string Serialize(List<T> array);
        Task PersistirAsync(string data);
        Guid GetNewGuid();
    }
}
