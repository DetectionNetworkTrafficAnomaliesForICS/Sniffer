using Lib.Models;

namespace Lib.Repositories.Interfaces;

public interface IFolderRepository
{
    bool TryGetByPath(string path, out IFolder? result, IFolder? defaultValue = default);
    bool TryCreateFile(IFolder folder, string name, out IFile? file);
}