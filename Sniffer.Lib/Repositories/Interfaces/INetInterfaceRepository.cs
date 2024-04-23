using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    bool TryGetByName(string name, out INetDevice? result, INetDevice? defaultValue = default);
    List<INetDevice> GetAll();
}