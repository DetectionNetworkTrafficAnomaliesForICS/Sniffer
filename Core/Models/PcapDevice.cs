using Lib.Models;
using PcapDotNet.Core;

namespace Core.Models;

public class PcapDevice : INetDevice
{
    private readonly IPacketDevice _captureDevice;

    public string Name { get; }

    public PcapDevice(IPacketDevice captureDevice)
    {
        _captureDevice = captureDevice;
        Name = captureDevice.Name;
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