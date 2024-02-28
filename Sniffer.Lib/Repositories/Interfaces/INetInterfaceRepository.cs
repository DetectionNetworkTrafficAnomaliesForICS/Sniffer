using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    List<NetInterface> GetAll();
    NetInterface GetDefaultGateway();
    NetInterface GetLoopback();
}