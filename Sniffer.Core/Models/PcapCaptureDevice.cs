using SharpPcap;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapCaptureDevice : INetCaptureDevice
{
    private readonly ICaptureDevice _captureDevice;
    private PacketArrivalEventHandler? OnPacketArrival { get; set; }

    public NetConfiguration NetConfiguration { get; }

    public PcapCaptureDevice(ICaptureDevice captureDevice)
    {
        _captureDevice = captureDevice;
        NetConfiguration = new NetConfiguration(captureDevice.Name);
    }


    public void Dispose()
    {
    }

    public override string ToString()
    {
        return _captureDevice.Description;
    }

    public void Stop()
    {
        _captureDevice.StopCapture();
        _captureDevice.OnPacketArrival -= OnPacketArrival;
        OnPacketArrival = null;
        _captureDevice.Close();
    }

    public void Start(INetCapture.PacketEventHandler onPacketArrival)
    {
        _captureDevice.Open();
        OnPacketArrival = (_, capture) => onPacketArrival(new PcapPacket(capture));
        _captureDevice.OnPacketArrival += OnPacketArrival;
        _captureDevice.StartCapture();
    }
}