using Sniffer.Lib.Configuration;

namespace Sniffer.Lib.Models;

public interface IFolder
{
    FolderConfiguration FolderConfiguration { get; }
}