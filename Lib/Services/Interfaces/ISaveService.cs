using Lib.Models;

namespace Lib.Services.Interfaces;

public interface ISaveService
{
    void SavePackets<T>(string name,  IListPackets packets, Func<INetPacket, IModbusPacket, T> fun);
}