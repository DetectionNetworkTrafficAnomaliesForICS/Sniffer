using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapStreamPacket(IAsyncEnumerable<PcapPacket> enumerable) : IStreamPackets
{
    public async Task<IListPackets> ToList()
    {
        var packets = await enumerable.ToListAsync();
        
        return await Task.FromResult(new PcapListPackets(packets));
    }

    public IStreamPackets Filtered(IFilter filter)
    {
        return new PcapStreamPacket(enumerable.Where(filter.Check));
    }

    public IStreamPackets Foreach(Action<INetPacket> func)
    {
        enumerable.ForEachAsync(func.Invoke);
        return this;
    }
}