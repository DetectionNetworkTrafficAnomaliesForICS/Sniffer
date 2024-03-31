using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapNetCatcher : INetCatcher
{
    private readonly PacketCommunicator _packetCommunicator;

    public PcapNetCatcher(PacketCommunicator packetCommunicator)
    {
        _packetCommunicator = packetCommunicator;
    }

    public async Task<IListPackets> ReceivePacket(IFilter filter, CancellationToken cancellationToken)
    {
        var packets = new PcapListPackets();
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