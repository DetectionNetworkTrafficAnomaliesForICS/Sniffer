using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class ModbusPacket : IModbusPacket
{
    public ModbusPacket(ushort transactionId, ushort protocolId, ushort lenRemainingPackage, byte deviceId,
        byte function, byte[] pdu, bool request)
    {
        TransactionId = transactionId;
        ProtocolId = protocolId;
        LenRemainingPackage = lenRemainingPackage;
        DeviceId = deviceId;
        Pdu = pdu;
        Request = request;
        Function = function;
    }

    public ushort TransactionId { get; }
    public ushort ProtocolId { get; }
    public ushort LenRemainingPackage { get; }
    public byte DeviceId { get; }
    public bool Request { get; }
    public ushort? AddressRegister { get; set; }
    public byte? CountByte { get; set; }
    public ushort? CountRegisters { get; set; }
    public byte[]? PayloadBytes { get; set; }
    public byte Function { get; }
    public byte[] Pdu { get; }
}