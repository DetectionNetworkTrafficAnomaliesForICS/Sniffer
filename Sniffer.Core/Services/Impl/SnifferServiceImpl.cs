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

    public async Task<List<INetPacket>> CapturePacketsAsync(INetDevice netDevice, IFilter filter,
        CancellationToken cancellationToken)
    {
        var packets = new List<INetPacket>();
        using var netCatcher = netDevice.Open(_appConfig.Value.RecheckingCancelTime);
        return await Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var code = netCatcher.ReceivePacket(out var packet);
                if (code == INetCatcher.ReceiveResult.Ok)
                {
                    if (filter.Check(packet!))
                    {
                        packets.Add(packet!);
                    }
                }
            }

            return Task.FromResult(packets);
        });
    }
}