using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface IDirectoryRepository
{
    bool TryGetByConfiguration(FolderConfiguration configuration, out IFolder? result, IFolder? defaultValue = default);
    bool TryGetDefaultFolder(out IFolder? result);
}