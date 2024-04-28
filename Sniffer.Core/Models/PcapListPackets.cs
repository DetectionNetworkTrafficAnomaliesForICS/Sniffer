﻿using System.Collections;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapListPackets(List<PcapPacket> packets) : IListPackets
{
    public IEnumerator<INetPacket> GetEnumerator()
    {
        return packets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}