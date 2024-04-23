using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class DeviceFilter : IFilter
{
    private IEnumerable<INetPacket.Device> Devices { get; }

    public DeviceFilter(IEnumerable<INetPacket.Device> devices)
    {
        Devices = devices;
    }

    public bool Check(INetPacket packet)
    {
        return Devices.Any(device => device == packet.SourceDevice || device == packet.DestinationDevice);
    }
}