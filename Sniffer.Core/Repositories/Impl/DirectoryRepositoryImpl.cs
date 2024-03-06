using Sniffer.Core.Models;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;
public class DirectoryRepositoryImpl : IDirectoryRepository
{
    public FolderConfiguration GetDefaultFolder()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        return new FolderConfiguration(currentDirectory);
    }

    public IFolder GetByConfiguration(FolderConfiguration configuration)
    {
        return new SystemFolder(configuration.Path);
    }
}