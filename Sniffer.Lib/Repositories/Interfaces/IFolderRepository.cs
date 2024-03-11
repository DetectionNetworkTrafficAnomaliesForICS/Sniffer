using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface IFolderRepository
{
    bool TryGetByConfiguration(FolderConfiguration configuration, out IFolder? result, IFolder? defaultValue = default);
    bool TryGetDefaultFolder(out IFolder? folder);
    bool TryCreateFile(IFolder folder, string name, out IFile? file);

}