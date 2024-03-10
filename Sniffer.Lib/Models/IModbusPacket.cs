namespace Sniffer.Lib.Models;

public interface IModbusPacket
{
    public ushort TransactionId { get; }
    public ushort ProtocolId { get; }
    public ushort LenRemainingPackage { get; }
    public byte DeviceId { get; }
    public byte[] Pdu { get; }
}