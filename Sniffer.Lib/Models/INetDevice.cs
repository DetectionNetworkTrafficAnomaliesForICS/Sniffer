using Sniffer.Lib.Configuration;

namespace Sniffer.Lib.Models;

public interface INetDevice : IDisposable
{
    public NetConfiguration NetConfiguration { get; }
    public event PacketEventHandler OnPacketArrival;
    public void Open();
    public void Start();
    public void Close();

    public delegate void PacketEventHandler(object sender, INetPacket netPacket);
}