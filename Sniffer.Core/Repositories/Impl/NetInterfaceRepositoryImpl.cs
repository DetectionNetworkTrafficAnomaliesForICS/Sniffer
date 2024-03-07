using SharpPcap;
using Sniffer.Core.Models;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public bool TryGet(NetConfiguration config, out INetCaptureDevice? result, INetCaptureDevice? defaultValue = default)
    {
        try
        {
            var allDevices = CaptureDeviceList.Instance;

            result = new PcapCaptureDevice(allDevices[config.Name]);
            return true;
        }
        catch (Exception)
        {
            result = defaultValue;
            return false;
        }
    }

    public List<INetCaptureDevice> GetAll()
    {
        var allDevices = CaptureDeviceList.Instance;
        return allDevices != null
            ? allDevices.Select(device => new PcapCaptureDevice(device)).ToList<INetCaptureDevice>()
            : new List<INetCaptureDevice>();
    }

    public bool TryGetDefault(out INetCaptureDevice? result)
    {
        var allDevices = CaptureDeviceList.Instance;

        try
        {
            result = new PcapCaptureDevice(allDevices[0]);
            return true;
        }
        catch (Exception)
        {
            result = null;
            return false;
        }
    }
}