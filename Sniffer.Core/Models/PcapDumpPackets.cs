using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapDumpPackets : IDumpPackets
{
    private IEnumerable<PcapPacket> Packets { get; }
    
    public PcapDumpPackets(IEnumerable<PcapPacket> packets)
    {
        Packets = packets;
    }

    public void Save(string pathName)
    {
       // PcapDumpPackets.Dump(pathName, DataLinkKind.Ethernet, 655360, Packets.Select(pcap => pcap.Packet));
    }
}