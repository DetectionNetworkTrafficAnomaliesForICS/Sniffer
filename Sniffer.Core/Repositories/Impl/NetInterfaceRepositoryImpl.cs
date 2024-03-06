using System.Net.NetworkInformation;
using SharpPcap;
using Sniffer.Core.Models;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public INetDevice? Get(NetConfiguration config)
    {
        var allDevices = CaptureDeviceList.Instance;
        return new PcapDevice(allDevices[config.Name]);
    }

    public List<INetDevice> GetAll()
    {
        var allDevices = CaptureDeviceList.Instance;
        return allDevices != null ? allDevices.Select(device => new PcapDevice(device)).ToList<INetDevice>() : new List<INetDevice>();
    }

    public NetConfiguration GetDefault()
    {
        return new NetConfiguration(CaptureDeviceList.Instance[4].Name);
    }
}