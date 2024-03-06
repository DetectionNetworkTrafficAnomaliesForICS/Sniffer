namespace Sniffer.Lib.Models;

public interface INetPacket
{
    public Device SourceDevice { get; }
    public Device DestinationDevice { get; }

    public uint Ttl { get; }
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }
    public uint CheckSum { get; }
    public byte[] Data { get; }

    public record Device(uint Port, string MacAddress, string IpAddress);
}