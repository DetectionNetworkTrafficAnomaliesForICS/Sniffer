using System.Net.NetworkInformation;
using SharpPcap;
using Sniffer.Core.Models;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public List<INetDevice> GetAll()
    {
        var allDevices = CaptureDeviceList.Instance;
        return allDevices.Select(device => new PcapDevice(device)).ToList<INetDevice>();
    }
    
    public INetDevice GetDefault()
    {
        return new PcapDevice(CaptureDeviceList.Instance[4]);
    }
}