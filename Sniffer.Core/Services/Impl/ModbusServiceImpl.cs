using System;
using Sniffer.Core.Models;
using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class ModbusServiceImpl : IModbusService
{
    public bool TryConvertToModbusPacket(INetPacket netPacket, out IModbusPacket? result)
    {
        var bytes = netPacket.Data;
        try
        {
            var tranId = BitConverter.ToUInt16(bytes, 0);
            var protocolId = BitConverter.ToUInt16(bytes, 2);
            var len = BitConverter.ToUInt16(bytes, 4);
            var deviceId = bytes[6];
            var pdu = new byte[bytes.Length - 7];
            Array.Copy(bytes, 7, pdu, 0, bytes.Length - 7);

            result = new ModbusPacket(tranId, protocolId, len, deviceId, pdu);
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }
}