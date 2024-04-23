using Core.Models;
using Lib.Models;
using Lib.Repositories.Interfaces;

namespace Core.Repositories.Impl;

public class FolderRepositoryImpl : IFolderRepository
{
    public bool TryGetByPath(string path, out IFolder? result, IFolder? defaultValue = default)
    {
        try
        {
            result = new SystemFolder(path);
            return true;
        }
        catch (Exception)
        {
            result = defaultValue;
            return false;
        }
    }

    public bool TryCreateFile(IFolder folder, string name, out IFile? file)
    {
        try
        {
            file = new SystemFile(folder.Path + name);
            return true;
        }
        catch (Exception)
        {
            file = default;
            return false;
        }
    }
}