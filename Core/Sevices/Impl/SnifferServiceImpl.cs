using Core.Configuration;
using Lib.Models;
using Lib.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Core.Sevices.Impl;

public class SnifferServiceImpl : ISnifferService
{
    private readonly IOptions<AppConfiguration> _appConfig;

    public SnifferServiceImpl(IOptions<AppConfiguration> appConfig)
    {
        _appConfig = appConfig;
    }

    public async Task<IListPackets> CapturePacketsAsync(INetDevice netDevice, IFilter filter,
        CancellationToken cancellationToken)
    {
        using var netCatcher = netDevice.Open(_appConfig.Value.RecheckingCancelTime);
        return await netCatcher.ReceivePacket(filter, cancellationToken);
    }
}