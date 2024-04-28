using PacketDotNet;
using SharpPcap;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapPacket : INetPacket
{
    public DateTime DateTime { get; }
    public INetDevice SourceDevice { get; }
    public INetDevice DestinationDevice { get; }

    public uint Ttl { get; }
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }
    public ushort CheckSum { get; }

    public byte[] Data { get; }

    public RawCapture RawPacket { get; }

    public PcapPacket(PacketCapture packetCapture)
    {
        DateTime = DateTime.Now;
        RawPacket = packetCapture.GetPacket();

        var packet = Packet.ParsePacket(RawPacket.LinkLayerType, RawPacket.Data);

        var ethernetPacket = packet.Extract<EthernetPacket>();
        var ipPacket = packet.Extract<IPPacket>();
        var tcpPacket = packet.Extract<TcpPacket>();

        SourceDevice = new NetDevice(tcpPacket.SourcePort
            , ethernetPacket.SourceHardwareAddress.ToString(), ipPacket.SourceAddress.ToString());
        DestinationDevice = new NetDevice(tcpPacket.DestinationPort
            , ethernetPacket.DestinationHardwareAddress.ToString(), ipPacket.DestinationAddress.ToString());

        Ttl = (uint)ipPacket.TimeToLive;
        AcknowledgementNumber = tcpPacket.AcknowledgmentNumber;
        SequenceNumber = tcpPacket.SequenceNumber;
        CheckSum = tcpPacket.Checksum;

        Data = tcpPacket.PayloadData ?? throw new ArgumentException("No contains payload");
    }
}