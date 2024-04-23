namespace Lib.Models;

public interface INetPacket
{
    DateTime DateTime { get; }
    Device SourceDevice { get; }
    Device DestinationDevice { get; }

    uint Ttl { get; }
    uint SequenceNumber { get; }
    uint AcknowledgementNumber { get; }
    ushort CheckSum { get; }
    byte[] Data { get; }

    class Device
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

        public static bool operator ==(Device left, Device right)
        {
            return left.Port == right.Port && left.IpAddress == right.IpAddress && left.MacAddress == right.MacAddress;
        }

        public static bool operator !=(Device left, Device right)
        {
            return !(left == right);
        }
    }
}