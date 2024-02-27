using Windows.Devices.SmartCards;
using Sniffer.Models;

namespace Sniffer.Repositories;

public interface INetInterfaceRepository
{
    List<NetInterface> GetAll();
    NetInterface GetDefaultGateway();
    NetInterface GetLoopback();
}