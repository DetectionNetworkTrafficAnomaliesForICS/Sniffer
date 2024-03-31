using System;
using System.Collections;
using System.Collections.Generic;
using PcapDotNet.Packets;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapListPackets : IListPackets
{
    private readonly List<Packet> _packets = [];

    public void Add(Packet packet)
    {
        _packets.Add(packet);
    }

    public IEnumerator<INetPacket> GetEnumerator()
    {
        foreach (var p in _packets)
        {
            PcapPacket? packet = null;
            try
            {
                packet = new PcapPacket(p);
            }
            catch (Exception)
            {
                // Обработка ошибки
            }

            if (packet != null)
            {
                yield return packet;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IDumpPackets GetDump
        => new PcapDumpPackets(_packets);
}