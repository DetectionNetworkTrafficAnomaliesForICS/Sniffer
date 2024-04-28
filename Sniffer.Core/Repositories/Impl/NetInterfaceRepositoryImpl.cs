using SharpPcap;
using Sniffer.Core.Models;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public bool TryGetByName(string name, out INetInterface? result, INetInterface? defaultValue = default)
    {
        try
        {
            var allDevices = CaptureDeviceList.Instance;
            foreach (var device in allDevices)
            {
                if (device.Name.Equals(name))
                {
                    result = new PcapInterface(device);
                    return true;
                }
            }
        }
        catch (Exception)
        {
            result = defaultValue;
            return false;
        }

        result = defaultValue;
        return false;
    }

    public List<INetInterface> GetAll()
    {
        var allDevices = CaptureDeviceList.Instance;
        return allDevices != null
            ? allDevices.Select(device => new PcapInterface(device)).ToList<INetInterface>()
            : new List<INetInterface>();
    }
}