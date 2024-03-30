using System;
using System.Linq;
using Sniffer.Core.Models;
using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class ModbusServiceImpl : IModbusService
{
    public bool TryConvertToModbusPacket(INetPacket netPacket, out IModbusPacket? result)
    {
        var bytes = netPacket.Data.Reverse().ToArray();
        try
        {
            var tranId = BitConverter.ToUInt16(bytes, bytes.Length - 2);
            var protocolId = BitConverter.ToUInt16(bytes, bytes.Length - 4);
            var len = BitConverter.ToUInt16(bytes, bytes.Length - 6);
            var deviceId = bytes[bytes.Length - 7];
            var function = bytes[bytes.Length - 8];
            var pdu = new byte[bytes.Length - 7];
            Array.Copy(bytes, 0, pdu, 0, bytes.Length - 7);

            result = new ModbusPacket(tranId, protocolId, len, deviceId, function, pdu);
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }
}