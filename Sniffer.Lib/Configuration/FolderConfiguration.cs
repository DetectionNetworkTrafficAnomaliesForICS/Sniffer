namespace Sniffer.Lib.Configuration;

public class FolderConfiguration
{
    public string Path { get; }
    
    public FolderConfiguration(string path)
    {
        Path = path;
    }

    public override string ToString()
    {
        return Path;
    }
}