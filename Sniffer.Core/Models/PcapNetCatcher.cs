using System.Threading.Channels;
using PcapDotNet.Core;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapNetCatcher  : INetCatcher
{
    private readonly PacketCommunicator _packetCommunicator;
    private readonly Channel<PcapPacket> _channel;
    
    public IStreamPackets StreamPackets => new PcapStreamPacket(_channel.Reader.ReadAllAsync());

    public PcapNetCatcher(PacketCommunicator packetCommunicator, int capacity)
    {
        _packetCommunicator = packetCommunicator;
        _channel = Channel.CreateBounded<PcapPacket>(new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        });
    }

    public async void Capture(CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var result = _packetCommunicator.ReceivePacket(out var p);
                if (result == PacketCommunicatorReceiveResult.Ok)
                {
                    PcapPacket? pcap;
                    try
                    {
                        pcap = new PcapPacket(p);
                    }
                    catch (Exception)
                    {
                     continue;
                    }
                    
                    _channel.Writer.WriteAsync(pcap, cancellationToken);
                }
            }
        }, cancellationToken);
        
        _channel.Writer.Complete();
    }

    public void Dispose()
    {
        _packetCommunicator.Break();
        _packetCommunicator.Dispose();
    }
}