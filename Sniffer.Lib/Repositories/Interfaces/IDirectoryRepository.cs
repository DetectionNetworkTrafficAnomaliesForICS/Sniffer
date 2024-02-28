using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface IDirectoryRepository
{
    public Folder GetDefaultDirectory();
}