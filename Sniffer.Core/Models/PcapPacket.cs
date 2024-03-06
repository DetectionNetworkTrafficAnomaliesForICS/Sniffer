using PacketDotNet;
using SharpPcap;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapPacket : INetPacket
{
    public PcapPacket(PacketCapture packetCapture)
    {
        var rawPacket = packetCapture.GetPacket();

        var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

        var ethernetPacket = packet.Extract<EthernetPacket>();
        var ipPacket = packet.Extract<IPPacket>();
        var tcpPacket = packet.Extract<TcpPacket>();

        SourceDevice = new INetPacket.Device(tcpPacket.SourcePort, 
            ipPacket.SourceAddress.ToString(),ethernetPacket.SourceHardwareAddress.ToString());
        DestinationDevice = new INetPacket.Device(tcpPacket.DestinationPort, 
            ethernetPacket.DestinationHardwareAddress.ToString(), ipPacket.DestinationAddress.ToString());
        
        Ttl = (uint)ipPacket.TimeToLive;
        AcknowledgementNumber = tcpPacket.AcknowledgmentNumber;
        SequenceNumber = tcpPacket.SequenceNumber;
        CheckSum = tcpPacket.Checksum;
        Data = tcpPacket.PayloadData;
    }

    public INetPacket.Device SourceDevice { get; }
    public INetPacket.Device DestinationDevice { get; }
    
    public uint Ttl { get; }
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }
    public uint CheckSum { get; }
    
    public byte[] Data { get; }
}