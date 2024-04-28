using System.Threading.Channels;
using SharpPcap;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapNetCatcher  : INetCatcher
{
    private readonly ICaptureDevice _captureDevice;
    private readonly Channel<PcapPacket> _channel;
    

    public PcapNetCatcher(ICaptureDevice captureDevice, int capacity)
    {
        _captureDevice = captureDevice;
        _channel = Channel.CreateBounded<PcapPacket>(new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.DropOldest
        });
    }

    void PacketArrivalEventHandler(object sender, PacketCapture e)
    {
        _channel.Writer.WriteAsync(new PcapPacket(e));
    }
    
    public void Dispose()
    {
        _captureDevice.Dispose();
    }

    public IStreamPackets StartCapture()
    {
        _captureDevice.OnPacketArrival += PacketArrivalEventHandler;
        _captureDevice.StartCapture();
        
        return new PcapStreamPacket(_channel.Reader.ReadAllAsync());
    }

    public void StopCapture()
    {
        _captureDevice.StopCapture();
        _channel.Writer.Complete();
        _captureDevice.OnPacketArrival -= PacketArrivalEventHandler;
    }
}