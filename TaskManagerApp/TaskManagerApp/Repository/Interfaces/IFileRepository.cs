using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using TaskManagerApp.Utils.Enum;

namespace TaskManagerApp.Repository.Interfaces
{
    public interface IFileRepository
    {
        bool DirectoryExists(DataFile file);

        void CreateDirectory(DataFile file);

        Stream GetDirectory(DataFile file, FileMode fileMode);

        string GetSourcePath(DataFile file);

        Task ClearFileAsync(string sourcePath);
    }
}
