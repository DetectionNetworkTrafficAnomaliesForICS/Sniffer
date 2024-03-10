﻿using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class ModbusPacket : IModbusPacket
{
    public ModbusPacket(ushort transactionId, ushort protocolId, ushort lenRemainingPackage, byte deviceId, byte[] pdu)
    {
        TransactionId = transactionId;
        ProtocolId = protocolId;
        LenRemainingPackage = lenRemainingPackage;
        DeviceId = deviceId;
        Pdu = pdu;
    }

    public ushort TransactionId { get; }
    public ushort ProtocolId { get; }
    public ushort LenRemainingPackage { get; }
    public byte DeviceId { get; }
    public byte[] Pdu { get; }
}