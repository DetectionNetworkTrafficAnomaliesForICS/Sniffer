using System;
using System.Collections;
using System.Collections.Generic;
using PcapDotNet.Packets;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapListPackets : IListPackets
{
    private readonly List<Packet> _packets = [];
    private readonly List<INetPacket> _pcapPackets = [];

    public IFilter? Filter { get; set; }

    public void Add(Packet packet)
    {
        PcapPacket? pcap;
        try
        {
            pcap = new PcapPacket(packet);
        }
        catch (Exception)
        {
            return;
        }

        if (Filter != null)
        {
            if (Filter.Check(pcap))
            {
                _pcapPackets.Add(pcap);
                _packets.Add(packet);
            }
        }
        else
        {
            _pcapPackets.Add(pcap);
            _packets.Add(packet);
        }
    }

    public IEnumerator<INetPacket> GetEnumerator()
    {
        return _pcapPackets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IDumpPackets GetDump
        => new PcapDumpPackets(_packets);
}