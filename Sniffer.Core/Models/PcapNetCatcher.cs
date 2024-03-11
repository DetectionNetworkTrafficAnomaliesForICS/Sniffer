using PcapDotNet.Core;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapNetCatcher : INetCatcher
{
    private readonly PacketCommunicator _packetCommunicator;

    public PcapNetCatcher(PacketCommunicator packetCommunicator)
    {
        _packetCommunicator = packetCommunicator;
    }

    public INetCatcher.ReceiveResult ReceivePacket(out INetPacket? packet)
    {
        var result = _packetCommunicator.ReceivePacket(out var p);
        switch (result)
        {
            case PacketCommunicatorReceiveResult.Ok:
                packet = new PcapPacket(p);
                return INetCatcher.ReceiveResult.Ok;
            case PacketCommunicatorReceiveResult.Timeout:
                packet = default;
                return INetCatcher.ReceiveResult.Timeout;
            default:
                packet = default;
                return INetCatcher.ReceiveResult.Error;
        }
    }

    public void Dispose()
    {
        _packetCommunicator.Break();
        _packetCommunicator.Dispose();
    }
}