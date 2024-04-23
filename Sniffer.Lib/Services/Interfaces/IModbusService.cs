using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface IModbusService
{
    bool TryConvertToModbusPacket(INetPacket netPacket, out IModbusPacket? result);
}