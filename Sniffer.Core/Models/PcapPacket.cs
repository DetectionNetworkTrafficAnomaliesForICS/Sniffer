﻿using System;
using System.Linq;
using PcapDotNet.Packets;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapPacket : INetPacket
{
    public PcapPacket(Packet packetCapture)
    {
        DateTime = DateTime.Now;
        var ethernetPacket = packetCapture.Ethernet;
        var ipPacket = ethernetPacket.IpV4;
        var tcpPacket = ipPacket.Tcp;

        SourceDevice = new INetPacket.Device(tcpPacket.SourcePort, 
            ipPacket.Source.ToString(),ethernetPacket.Source.ToString());
        DestinationDevice = new INetPacket.Device(tcpPacket.DestinationPort, 
            ethernetPacket.Destination.ToString(), ipPacket.Destination.ToString());
        
        Ttl = ipPacket.Ttl;
        AcknowledgementNumber = tcpPacket.AcknowledgmentNumber;
        SequenceNumber = tcpPacket.SequenceNumber;
        CheckSum = tcpPacket.Checksum;
        Data = tcpPacket.Payload.ToArray();
    }

    public DateTime DateTime { get; }
    public INetPacket.Device SourceDevice { get; }
    public INetPacket.Device DestinationDevice { get; }
    
    public uint Ttl { get; }
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }
    public uint CheckSum { get; }
    
    public byte[] Data { get; }
}