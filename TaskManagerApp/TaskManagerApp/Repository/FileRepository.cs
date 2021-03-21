using Microsoft.Extensions.Options;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using TaskManagerApp.Configuration;
using TaskManagerApp.Repository.Interfaces;
using TaskManagerApp.Utils.Enum;

namespace TaskManagerApp.Repository
{
    public class FileRepository : IFileRepository
    {
        private IFileSystem _fileSystem;
        private readonly string _sourcePath;
        private readonly string _extensionFile;

        public FileRepository(IFileSystem fileSystem, IOptions<Settings> settings)
        {
            _fileSystem = fileSystem;
            _sourcePath = settings.Value.SourcePath;
            _extensionFile = settings.Value.ExtensionFile;
        }

        public bool DirectoryExists(DataFile file)
        {
            return _fileSystem.File.Exists(_sourcePath + file.ToString() + _extensionFile);
        }

        public void CreateDirectory(DataFile file)
        {
            if(!DirectoryExists(file))
            {
                try
                {
                    _fileSystem.File.Create(_sourcePath + file.ToString() + _extensionFile);
                }
                catch(IOException e)
                {
                    //armazenar log
                }
            }
        }

        public Stream GetDirectory(DataFile file, FileMode fileMode)
        {
            return _fileSystem.File.Open(_sourcePath + file.ToString() + _extensionFile, fileMode);
        }

        public string GetSourcePath(DataFile file)
        {
            return _sourcePath + file.ToString() + _extensionFile;
        }

        public async Task ClearFileAsync(string sourcePath)
        {
            await _fileSystem.File.WriteAllTextAsync(sourcePath, string.Empty);
        }
    }
}
