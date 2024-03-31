using System.IO;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class SystemFile : IFile
{
    public string Path { get; }

    public SystemFile(string path)
    {
        Path = path;
    }

    public StreamWriter Writer => new(Path);
    public StreamReader Reader => new(Path);
}