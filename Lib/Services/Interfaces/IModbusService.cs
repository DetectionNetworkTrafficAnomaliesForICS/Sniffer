using Lib.Models;

namespace Lib.Services.Interfaces;

public interface IModbusService
{
    bool TryConvertToModbusPacket(INetPacket netPacket, out IModbusPacket? result);
}