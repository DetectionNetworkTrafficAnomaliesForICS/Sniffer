using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class NetDevice : INetDevice
{
    
    public uint Port { get; }
    public string MacAddress { get; }
    public string IpAddress { get; }
    
    public NetDevice(uint port, string macAddress, string ipAddress)
    {
        Port = port;
        MacAddress = macAddress;
        IpAddress = ipAddress;
    }
    
    public bool Compare(INetDevice device)
    {
        return Port == device.Port && IpAddress == device.IpAddress && MacAddress == device.MacAddress;
    }
}