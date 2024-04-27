using PcapDotNet.Core;
using PcapDotNet.Packets;
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
       PacketDumpFile.Dump(pathName, DataLinkKind.Ethernet, 655360, Packets.Select(pcap => pcap.Packet));
    }
}