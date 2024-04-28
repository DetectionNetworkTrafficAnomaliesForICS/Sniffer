using PacketDotNet;
using SharpPcap;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapPacket : INetPacket
{
    public DateTime DateTime { get; }
    public INetPacket.Device SourceDevice { get; }
    public INetPacket.Device DestinationDevice { get; }

    public uint Ttl { get; }
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }
    public ushort CheckSum { get; }

    public byte[] Data { get; }

    // public PacketCapture Packet { get; }

    public PcapPacket(PacketCapture packetCapture)
    {
        DateTime = DateTime.Now;
        var rawPacket = packetCapture.GetPacket();

        var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

        var ethernetPacket = packet.Extract<EthernetPacket>();
        var ipPacket = packet.Extract<IPPacket>();
        var tcpPacket = packet.Extract<TcpPacket>();

        SourceDevice = new INetPacket.Device(tcpPacket.SourcePort
            , ethernetPacket.SourceHardwareAddress.ToString(), ipPacket.SourceAddress.ToString());
        DestinationDevice = new INetPacket.Device(tcpPacket.DestinationPort
            , ethernetPacket.DestinationHardwareAddress.ToString(), ipPacket.DestinationAddress.ToString());

        Ttl = (uint)ipPacket.TimeToLive;
        AcknowledgementNumber = tcpPacket.AcknowledgmentNumber;
        SequenceNumber = tcpPacket.SequenceNumber;
        CheckSum = tcpPacket.Checksum;

        Data = tcpPacket.PayloadData ?? throw new ArgumentException("No contains payload");
    }
}