using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISnifferService
{
    public Task ListenTrafficByDevice(Folder folder, NetInterface netInterface);
}