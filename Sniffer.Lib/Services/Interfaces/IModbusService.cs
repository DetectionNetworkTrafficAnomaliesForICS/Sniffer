using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface IModbusService
{
    public bool TryConvertToModbusPacket(INetPacket netPacket, out IModbusPacket? result);
}