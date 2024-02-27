using Sniffer.Models;

namespace Sniffer.Services;

public interface INetService
{
    List<NetInterface> GetAll();
}