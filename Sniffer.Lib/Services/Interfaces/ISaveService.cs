using System.Collections.Generic;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISaveService
{
    void WritePackets(string name, IEnumerable<INetPacket> list);
}