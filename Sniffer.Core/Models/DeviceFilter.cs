using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        foreach (var device in Devices)
        {
            if (packet.SourceDevice.Port == device.Port &&
                packet.SourceDevice.IpAddress == device.IpAddress ||
                packet.DestinationDevice.IpAddress == device.IpAddress &&
                packet.DestinationDevice.Port == device.Port
               )
                return true;
        }

        return false;
    }
}