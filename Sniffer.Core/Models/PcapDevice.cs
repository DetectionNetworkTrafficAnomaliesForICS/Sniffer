using PcapDotNet.Core;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapDevice : INetDevice
{
    private readonly IPacketDevice _captureDevice;

    public NetConfiguration NetConfiguration { get; }

    public PcapDevice(IPacketDevice captureDevice)
    {
        _captureDevice = captureDevice;

        NetConfiguration = new NetConfiguration(captureDevice.Name);
    }

    public INetCatcher Open(int timeout)
    {
        return new PcapNetCatcher(_captureDevice.Open(655360, PacketDeviceOpenAttributes.Promiscuous, timeout));
    }

    public void Close()
    {
        
    }
    
    public override string ToString()
    {
        return _captureDevice.Description;
    }
}