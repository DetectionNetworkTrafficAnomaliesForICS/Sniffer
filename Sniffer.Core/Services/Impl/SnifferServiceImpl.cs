using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class SnifferServiceImpl : ISnifferService
{
    private readonly AppConfiguration _appConfig;

    public SnifferServiceImpl(IOptions<AppConfiguration> appConfig)
    {
        _appConfig = appConfig.Value;
    }

    public async Task<IListPackets> CapturePacketsAsync(INetDevice netDevice, IFilter filter,
        CancellationToken cancellationToken)
    {
        using var netCatcher = netDevice.Open(_appConfig.RecheckingCancelTime, _appConfig.CapacityPackets);
        netCatcher.Capture(cancellationToken);
        return await netCatcher.StreamPackets.Filtered(filter).ToList();
    }
}