using System.Threading.Channels;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using Sniffer.Lib.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sniffer.Core.Models;

public class PcapStreamPacket(IAsyncEnumerable<PcapPacket> enumerable) : IStreamPackets
{
    public void Dispose()
    {
        // _packetCommunicator.Break();
        // _packetCommunicator.Dispose();
    }

    public async Task<IListPackets> ToList()
    {
        var packets = await enumerable.ToListAsync();
        
        return await Task.FromResult(new PcapListPackets(packets));
    }

    public IStreamPackets Filtered(IFilter filter)
    {
        return new PcapStreamPacket(enumerable.Where(filter.Check));
    }
}