using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class CsvPacket
{
    public string DateTime { get; }

    public uint SourcePort { get; }
    public string SourceMacAddress { get; }
    public string SourceIpAddress { get; }

    public uint DestinationPort { get; }
    public string DestinationMacAddress { get; }
    public string DestinationIpAddress { get; }
    
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }

    public byte[] PayloadTcp { get; }
    
    public IModbusPacket Packet { get; }
    
    public bool Anomaly { get; }

    public CsvPacket(IModbusPacket modbusPacket, INetPacket netPacket)
    {
        SourcePort = netPacket.SourceDevice.Port;
        SourceIpAddress = netPacket.SourceDevice.IpAddress;
        SourceMacAddress = netPacket.SourceDevice.MacAddress;

        DestinationPort = netPacket.DestinationDevice.Port;
        DestinationIpAddress = netPacket.DestinationDevice.IpAddress;
        DestinationMacAddress = netPacket.DestinationDevice.MacAddress;
        
        SequenceNumber = netPacket.SequenceNumber;
        AcknowledgementNumber = netPacket.AcknowledgementNumber;

        Packet = modbusPacket;
        PayloadTcp = netPacket.Data;
        DateTime = netPacket.DateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        
        Anomaly = modbusPacket.PayloadBytes != null &&
                  modbusPacket.Request && BitConverter.ToSingle(modbusPacket.PayloadBytes, 0) > 10f;
    }
}