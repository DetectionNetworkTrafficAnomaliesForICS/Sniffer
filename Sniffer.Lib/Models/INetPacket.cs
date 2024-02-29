namespace Sniffer.Lib.Models;

public interface INetPacket
{
    public Device SourceDevice { get; }
    public Device DestinationDevice { get; }

    public byte[] Data { get; }

    public record Device(int Port, string MacAddress, string IpAddress);
}