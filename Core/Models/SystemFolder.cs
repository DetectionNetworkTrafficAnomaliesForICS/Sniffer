using Lib.Models;

namespace Core.Models;

public class SystemFolder : IFolder
{
    public string Path { get; }


    public SystemFolder(string path)
    {
        Path = path;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
}