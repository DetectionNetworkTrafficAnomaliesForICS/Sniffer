namespace Sniffer.Lib.Models;

public interface INetPacket
{
    DateTime DateTime { get; }
    INetDevice SourceDevice { get; }
    INetDevice DestinationDevice { get; }

    uint Ttl { get; }
    uint SequenceNumber { get; }
    uint AcknowledgementNumber { get; }
    ushort CheckSum { get; }
    byte[] Data { get; }

}