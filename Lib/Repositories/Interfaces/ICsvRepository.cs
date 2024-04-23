using Lib.Models;

namespace Lib.Repositories.Interfaces;

public interface ICsvRepository
{
    bool TryWriteCsvFile<T>(IFile file, IEnumerable<T> list);
}