using Sniffer.Lib.Configuration;

namespace Sniffer.Lib.Models;

public interface IFolder
{
    public FolderConfiguration FolderConfiguration { get; }
}