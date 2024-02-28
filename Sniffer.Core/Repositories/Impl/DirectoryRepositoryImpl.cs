using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;
public class DirectoryRepositoryImpl : IDirectoryRepository
{
    public Folder GetDefaultDirectory()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        return new Folder(currentDirectory);
    }
}