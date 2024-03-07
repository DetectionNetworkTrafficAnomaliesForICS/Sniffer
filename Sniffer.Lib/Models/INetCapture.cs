namespace Sniffer.Lib.Models;

public interface INetCapture
{
    public void Stop();
    public void Start(PacketEventHandler onPacketArrival);
    
    public delegate void PacketEventHandler(INetPacket netPacket);
}