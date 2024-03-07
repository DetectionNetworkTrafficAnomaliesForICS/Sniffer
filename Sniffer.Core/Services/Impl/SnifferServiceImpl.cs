using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class SnifferServiceImpl : ISnifferService
{
    
    public int RecheckingTime { get; }
    
    public SnifferServiceImpl(int recheckingTime)
    {
        RecheckingTime = recheckingTime;
    }

    public async Task<List<INetPacket>> CapturePacketsAsync(INetCapture netDeviceCapture,
        CancellationToken cancellationToken)
    {
        var packets = new List<INetPacket>();
        
        netDeviceCapture.Start(delegate(INetPacket netPacket) { packets.Add(netPacket); });

        while (!cancellationToken.IsCancellationRequested)
        {   
            await Task.Delay(RecheckingTime);
        }

        netDeviceCapture.Stop();

        return packets;
    }
}