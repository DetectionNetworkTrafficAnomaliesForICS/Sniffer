using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class SystemFolder : IFolder
{
    public FolderConfiguration FolderConfiguration { get; }

    public SystemFolder(string path)
    {
        FolderConfiguration = new FolderConfiguration(path);
    }
}