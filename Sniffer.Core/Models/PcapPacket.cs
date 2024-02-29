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

        SourceDevice = new INetPacket.Device(tcpPacket.SourcePort, ethernetPacket.SourceHardwareAddress.ToString(),
            ipPacket.SourceAddress.ToString());
        DestinationDevice = new INetPacket.Device(tcpPacket.DestinationPort, ipPacket.DestinationAddress.ToString(),
            ethernetPacket.DestinationHardwareAddress.ToString());
        Data = tcpPacket.PayloadData;
    }

    public INetPacket.Device SourceDevice { get; }
    public INetPacket.Device DestinationDevice { get; }
    public byte[] Data { get; }
}