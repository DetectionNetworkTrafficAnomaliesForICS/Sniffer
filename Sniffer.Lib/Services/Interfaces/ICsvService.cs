using System.Collections.Generic;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ICsvService
{
    void WriteModbusPackets(string name, List<INetPacket> list);
}