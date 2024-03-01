using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class SystemFolder: IFolder
{
    public SystemFolder(string path)
    {
        Path = path;
    }

    public string Path { get; }
}