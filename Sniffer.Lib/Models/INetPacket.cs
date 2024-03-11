using System;

namespace Sniffer.Lib.Models;

public interface INetPacket
{
    public DateTime DateTime { get; }
    public Device SourceDevice { get; }
    public Device DestinationDevice { get; }

    public uint Ttl { get; }
    public uint SequenceNumber { get; }
    public uint AcknowledgementNumber { get; }
    public uint CheckSum { get; }
    public byte[] Data { get; }

    public class Device
    {
        
        public uint Port { get; }
        public string MacAddress { get; }
        public string IpAddress { get; }
        
        public Device(uint port, string macAddress, string ipAddress)
        {
            Port = port;
            MacAddress = macAddress;
            IpAddress = ipAddress;
        }
    }
 
}