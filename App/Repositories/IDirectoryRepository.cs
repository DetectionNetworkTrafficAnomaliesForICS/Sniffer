using Directory = Sniffer.Models.Directory;

namespace Sniffer.Repositories;

public interface IDirectoryRepository
{
    public Directory GetDefaultDirectory();
}