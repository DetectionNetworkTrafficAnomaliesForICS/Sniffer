using System.Collections.Generic;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ICsvService
{
    public void WriteModbusPackets(string name, List<INetPacket> list);
}