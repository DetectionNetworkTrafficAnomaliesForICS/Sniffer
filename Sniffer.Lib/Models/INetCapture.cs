using System.Threading;

namespace Sniffer.Lib.Models;

public interface INetCapture
{
    public void Capture(CancellationToken cancellationToken,PacketEventHandler onPacketArrival);
    
    public delegate void PacketEventHandler(INetPacket netPacket);
}