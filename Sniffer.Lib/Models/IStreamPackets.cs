using System.Net.Sockets;

namespace Sniffer.Lib.Models;

public interface IStreamPackets 
{
    Task<IListPackets> ToList();
    IStreamPackets Filtered(IFilter filter);
    IStreamPackets Foreach(Action<INetPacket> func);
}