namespace Lib.Models;

public interface IListPackets : IEnumerable<INetPacket>
{
    IFilter? Filter { get; set; }
    IDumpPackets GetDump { get; }
}