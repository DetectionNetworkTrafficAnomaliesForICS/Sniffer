
namespace Sniffer.Lib.Models;

public interface INetDevice : IDisposable
{
    public string Name { get; }
    public  event PacketEventHandler OnPacketArrival;
    public  void Open();
    public void Start();
    public void Close();

    public delegate void PacketEventHandler(object sender, INetPacket netPacket);
}