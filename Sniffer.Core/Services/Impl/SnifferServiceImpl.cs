using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

    public Task<List<INetPacket>> CapturePacketsAsync(INetCapture netDeviceCapture,
        CancellationToken cancellationToken)
    {
        var packets = new List<INetPacket>();

        netDeviceCapture.Capture(cancellationToken, delegate(INetPacket netPacket) { packets.Add(netPacket); });

        return Task.FromResult(packets);
    }
}