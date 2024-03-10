using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class SnifferServiceImpl : ISnifferService
{
    private readonly IOptions<AppConfiguration> _appConfig;
    
    public SnifferServiceImpl(IOptions<AppConfiguration> appConfig)
    {
        _appConfig = appConfig;
    }

    public async Task<List<INetPacket>> CapturePacketsAsync(INetCapture netDeviceCapture,
        CancellationToken cancellationToken)
    {
        var packets = new List<INetPacket>();
        
        netDeviceCapture.Start(delegate(INetPacket netPacket) { packets.Add(netPacket); });

        while (!cancellationToken.IsCancellationRequested)
        {   
            await Task.Delay(_appConfig.Value.RecheckingCancelTime);
        }

        netDeviceCapture.Stop();

        return packets;
    }
}