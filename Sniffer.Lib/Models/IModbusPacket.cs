namespace Sniffer.Lib.Models;

public interface IModbusPacket
{
    ushort TransactionId { get; }
    ushort ProtocolId { get; }
    ushort LenRemainingPackage { get; }
    byte DeviceId { get; }
    bool Request { get; }
    byte[] Pdu { get; }
}