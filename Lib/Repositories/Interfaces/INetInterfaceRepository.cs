using Lib.Models;

namespace Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    bool TryGetByName(string name, out INetDevice? result, INetDevice? defaultValue = default);
    List<INetDevice> GetAll();
}