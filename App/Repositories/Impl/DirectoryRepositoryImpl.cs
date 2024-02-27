using Directory = Sniffer.Models.Directory;

namespace Sniffer.Repositories.Impl;

public class DirectoryRepositoryImpl: IDirectoryRepository
{
    public Directory GetDefaultDirectory()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        return new Directory(currentDirectory);
    }
}