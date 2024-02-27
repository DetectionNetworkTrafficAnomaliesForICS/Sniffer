using Directory = Sniffer.Models.Directory;

namespace Sniffer.Services;

public interface IDirectoryService
{
    public Task<Directory> PickDirectory();
}