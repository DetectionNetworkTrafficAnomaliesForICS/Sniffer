using System;
using System.Collections.Generic;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISaveService
{
    void SavePackets<T>(string name,  IListPackets packets, Func<INetPacket, IModbusPacket, T> fun);
}