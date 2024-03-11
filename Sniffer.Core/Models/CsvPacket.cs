using System;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class CsvPacket
{
    public DateTime DateTime { get; }

    public uint SourcePort { get; }
    public string SourceMacAddress { get; }
    public string SourceIpAddress { get; }

    public uint DestinationPort { get; }
    public string DestinationMacAddress { get; }
    public string DestinationIpAddress { get; }

    public uint Ttl { get; }
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }
    public uint CheckSum { get; }

    public IModbusPacket Packet { get; }

    public CsvPacket(IModbusPacket modbus, INetPacket netPacket)
    {
        SourcePort = netPacket.SourceDevice.Port;
        SourceIpAddress = netPacket.SourceDevice.IpAddress;
        SourceMacAddress = netPacket.SourceDevice.MacAddress;

        DestinationPort = netPacket.DestinationDevice.Port;
        DestinationIpAddress = netPacket.DestinationDevice.IpAddress;
        DestinationMacAddress = netPacket.DestinationDevice.MacAddress;

        Ttl = netPacket.Ttl;
        SequenceNumber = netPacket.SequenceNumber;
        AcknowledgementNumber = netPacket.AcknowledgementNumber;
        CheckSum = netPacket.CheckSum;

        Packet = modbus;
        DateTime = netPacket.DateTime;
    }
}