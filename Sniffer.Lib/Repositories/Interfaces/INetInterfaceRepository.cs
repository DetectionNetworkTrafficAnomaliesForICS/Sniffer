using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    bool TryGet(NetConfiguration config, out INetDevice? result, INetDevice? defaultValue = default);
    List<INetDevice> GetAll();
    bool TryGetDefault(out INetDevice? result);
}