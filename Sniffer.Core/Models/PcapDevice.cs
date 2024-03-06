using SharpPcap;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapDevice : INetDevice
{
    private readonly ICaptureDevice _captureDevice;

    public NetConfiguration NetConfiguration { get; }
    public event INetDevice.PacketEventHandler? OnPacketArrival;

    public PcapDevice(ICaptureDevice captureDevice)
    {
        _captureDevice = captureDevice;
        NetConfiguration = new NetConfiguration(captureDevice.Name);
    }

    private void PacketEventHandler(object sender, PacketCapture packetCapture)
    {
        OnPacketArrival?.Invoke(sender, new PcapPacket(packetCapture));
    }

    public void Open()
    {
        _captureDevice.OnPacketArrival += PacketEventHandler;
        _captureDevice.Open(DeviceModes.Promiscuous, 1000);
    }

    public void Start()
    {
        string filter = "tcp";
        _captureDevice.Filter = filter;
        _captureDevice.StartCapture();
    }

    public void Close()
    {
        _captureDevice.StopCapture();
    }

    public void Dispose()
    {
        if (_captureDevice.Started)
        {
            _captureDevice.StopCapture();
        }
    }

    public override string ToString()
    {
        return _captureDevice.Description;
    }
}