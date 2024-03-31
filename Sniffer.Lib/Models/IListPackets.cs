using System.Collections.Generic;
using System.Data;

namespace Sniffer.Lib.Models;

public interface IListPackets : IEnumerable<INetPacket>
{
    IFilter? Filter { get; set; }
    IDumpPackets GetDump { get; }
}