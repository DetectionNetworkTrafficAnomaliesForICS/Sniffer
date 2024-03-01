using Sniffer.Core.Models;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;
public class DirectoryRepositoryImpl : IDirectoryRepository
{
    public IFolder GetDefaultDirectory()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        return new SystemFolder(currentDirectory);
    }
}