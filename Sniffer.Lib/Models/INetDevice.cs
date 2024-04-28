namespace Sniffer.Lib.Models;

public interface INetDevice
{
    uint Port { get; }
    string MacAddress { get; }
    string IpAddress { get; }

    bool Compare(INetDevice device);
}