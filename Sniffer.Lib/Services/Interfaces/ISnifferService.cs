using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISnifferService
{
    public List<INetPacket> CapturePackets(INetDevice netDevice);
}