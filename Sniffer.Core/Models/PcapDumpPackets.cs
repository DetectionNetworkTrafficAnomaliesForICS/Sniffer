using PcapDotNet.Packets;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapDumpPackets : IDumpPackets
{
    private IEnumerable<Packet> Packets { get; }
    
    public PcapDumpPackets(IEnumerable<Packet> packets)
    {
        Packets = packets;
    }

    public void Save(string pathName)
    {
       // PacketDumpFile.Dump(pathName, DataLinkKind.Ethernet, 655360, Packets);
    }
}