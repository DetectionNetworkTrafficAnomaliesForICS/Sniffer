using System.Windows.Markup;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface IDirectoryRepository
{
    public FolderConfiguration GetDefaultFolder();
    public IFolder? GetByConfiguration(FolderConfiguration configuration);
}