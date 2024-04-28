using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    bool TryGetByName(string name, out INetInterface? result, INetInterface? defaultValue = default);
    List<INetInterface> GetAll();
}