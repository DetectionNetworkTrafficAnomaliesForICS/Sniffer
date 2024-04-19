namespace Sniffer.Lib.Models;

public interface 
    IModbusPacket
{
    ushort TransactionId { get; }
    ushort ProtocolId { get; }
    ushort LenRemainingPackage { get; }
    byte DeviceId { get; }
    bool Request { get; }
    ushort? AddressRegister { get; }
    byte? CountByte { get; }
    ushort? CountRegisters { get; }
    byte[]? PayloadBytes { get; }
    public byte Function { get; }
}