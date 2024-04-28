using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class DeviceFilter : IFilter
{
    private IEnumerable<INetDevice> Devices { get; }

    public DeviceFilter(IEnumerable<INetDevice> devices)
    {
        Devices = devices;
    }

    public bool Check(INetPacket packet)
    {
        return Devices.Any(device => device.Compare(packet.SourceDevice) || device.Compare(packet.DestinationDevice));
    }
}