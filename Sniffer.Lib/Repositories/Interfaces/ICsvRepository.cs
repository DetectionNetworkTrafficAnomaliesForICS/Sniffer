using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface ICsvRepository
{
    bool TryWriteCsvFile<T>(IFile file, IEnumerable<T> list);
}