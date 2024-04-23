using Lib.Models;
using PcapDotNet.Core;

namespace Core.Models;

public class PcapNetCatcher : INetCatcher
{
    private readonly PacketCommunicator _packetCommunicator;

    public PcapNetCatcher(PacketCommunicator packetCommunicator)
    {
        _packetCommunicator = packetCommunicator;
    }

    public async Task<IListPackets> ReceivePacket(IFilter filter, CancellationToken cancellationToken)
    {
        var packets = new PcapListPackets
        {
            Filter = filter
        };
        return await Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var result = _packetCommunicator.ReceivePacket(out var p);
                if (result == PacketCommunicatorReceiveResult.Ok)
                {
                    packets.Add(p);
                }
            }

            return Task.FromResult(packets);
        });
    }

    public void Dispose()
    {
        _packetCommunicator.Break();
        _packetCommunicator.Dispose();
    }
}