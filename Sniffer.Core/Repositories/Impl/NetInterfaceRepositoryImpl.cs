using SharpPcap;
using Sniffer.Core.Models;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public bool TryGet(NetConfiguration config, out INetDevice? result, INetDevice? defaultValue = default)
    {
        try
        {
            var allDevices = CaptureDeviceList.Instance;

            result = new PcapDevice(allDevices[config.Name]);
            return true;
        }
        catch (Exception)
        {
            result = defaultValue;
            return false;
        }
    }

    public List<INetDevice> GetAll()
    {
        var allDevices = CaptureDeviceList.Instance;
        return allDevices != null
            ? allDevices.Select(device => new PcapDevice(device)).ToList<INetDevice>()
            : new List<INetDevice>();
    }

    public bool TryGetDefault(out INetDevice? result)
    {
        var allDevices = CaptureDeviceList.Instance;

        try
        {
            result = new PcapDevice(allDevices[0]);
            return true;
        }
        catch (Exception)
        {
            result = null;
            return false;
        }
    }
}