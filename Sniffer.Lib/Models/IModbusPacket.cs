namespace Sniffer.Lib.Models;

public interface IModbusPacket
{
    ushort TransactionId { get; }
    ushort ProtocolId { get; }
    ushort LenRemainingPackage { get; }
    byte DeviceId { get; }
    bool Request { get; }
    ushort? AddressRegister { get; }
    byte? CountByte { get; }
    ushort? CountRegisters { get; }
    byte[]? ReadBytes { get; }
    public byte Function { get; }
    byte[] Pdu { get; }
}