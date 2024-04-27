using PcapDotNet.Core;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapDevice : INetDevice
{
    private readonly IPacketDevice _captureDevice;
    public string Name => _captureDevice.Name;

    public PcapDevice(IPacketDevice captureDevice)
    {
        _captureDevice = captureDevice;
    }

    public INetCatcher Open(int timeout, int capacity)
    {
        return new PcapNetCatcher(_captureDevice.Open(655360, PacketDeviceOpenAttributes.Promiscuous, timeout),
            capacity);
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return _captureDevice.Description;
    }
}