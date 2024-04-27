namespace Sniffer.Lib.Models;

public interface IListPackets : IEnumerable<INetPacket>
{
    IDumpPackets GetDumpPackets { get; }
}