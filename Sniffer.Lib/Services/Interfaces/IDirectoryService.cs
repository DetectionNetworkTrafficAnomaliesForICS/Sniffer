using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface IDirectoryService
{
    public Task<Folder> PickDirectory();
}