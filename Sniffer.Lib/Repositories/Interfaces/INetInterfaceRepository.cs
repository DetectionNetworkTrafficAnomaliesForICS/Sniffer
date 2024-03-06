using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    INetDevice? Get(NetConfiguration config);
    List<INetDevice> GetAll();
    NetConfiguration GetDefault();
}