using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    List<INetDevice> GetAll();
    INetDevice GetDefault();
}