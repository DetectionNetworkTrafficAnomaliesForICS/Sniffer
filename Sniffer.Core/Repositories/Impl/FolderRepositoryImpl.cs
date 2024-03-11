using System;
using Sniffer.Core.Models;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class FolderRepositoryImpl : IFolderRepository
{
    public bool TryGetByConfiguration(FolderConfiguration configuration, out IFolder? result,
        IFolder? defaultValue = default)
    {
        try
        {
            result = new SystemFolder(configuration.Path);
            return true;
        }
        catch (Exception)
        {
            result = defaultValue;
            return false;
        }
    }

    public bool TryGetDefaultFolder(out IFolder? result)
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        result = new SystemFolder(currentDirectory);
        return true;
    }

    public bool TryCreateFile(IFolder folder, string name, out IFile? file)
    {
        try
        {
            file = new SystemFile(folder.FolderConfiguration.Path + name);
            return true;
        }
        catch (Exception)
        {
            file = default;
            return false;
        }
    }
}