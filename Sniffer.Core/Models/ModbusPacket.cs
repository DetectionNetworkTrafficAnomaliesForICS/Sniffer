using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class ModbusPacket : IModbusPacket
{
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
    
    public ModbusPacket(ushort transactionId, ushort protocolId, ushort lenRemainingPackage, byte deviceId,
        byte function,bool request)
    {
        TransactionId = transactionId;
        ProtocolId = protocolId;
        LenRemainingPackage = lenRemainingPackage;
        DeviceId = deviceId;
        Request = request;
        Function = function;
    }
    
}