using System.Net.Sockets;

namespace Sniffer.Lib.Models;

public interface IStreamPackets : IDisposable
{
    Task<IListPackets> ToList();
    IStreamPackets Filtered(IFilter filter);
}