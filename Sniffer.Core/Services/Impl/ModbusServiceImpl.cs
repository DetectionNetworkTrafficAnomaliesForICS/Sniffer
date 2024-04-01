using System;
using System.Linq;
using CsvHelper;
using Sniffer.Core.Models;
using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class ModbusServiceImpl : IModbusService
{
    private readonly ISettingsService _settingsService;

    public ModbusServiceImpl(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public bool TryConvertToModbusPacket(INetPacket netPacket, out IModbusPacket? result)
    {
        var bytes = netPacket.Data.Reverse().ToArray();
        try
        {
            var request = _settingsService.ModbusServers.Any(device => device == netPacket.DestinationDevice);
            var tranId = BitConverter.ToUInt16(bytes, bytes.Length - 2);
            var protocolId = BitConverter.ToUInt16(bytes, bytes.Length - 4);
            var len = BitConverter.ToUInt16(bytes, bytes.Length - 6);
            var deviceId = bytes[bytes.Length - 7];
            var function = bytes[bytes.Length - 8];
            var pdu = new byte[bytes.Length - 7];
            Array.Copy(bytes, 0, pdu, 0, bytes.Length - 7);

            var f = new ModbusPacket(tranId, protocolId, len, deviceId, function, pdu, request);
            ParserFun(request, function, bytes, f);

            result = f;
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }

    private void ParserFun(bool request, byte funCode, byte[] bytes, ModbusPacket packet)
    {
        if (funCode is 1 or 2 or 3 or 4)
        {
            if (request)
            {
                packet.AddressRegister = BitConverter.ToUInt16(bytes, bytes.Length - 10);
                packet.CountRegisters = BitConverter.ToUInt16(bytes, bytes.Length - 12);
            }
            else
            {
                packet.CountByte = bytes[bytes.Length - 9];
                packet.ReadBytes = new byte[(int)packet.CountByte];
                Array.Copy(bytes, 0, packet.ReadBytes, 0, (int)packet.CountByte);
            }
        }
    }
}