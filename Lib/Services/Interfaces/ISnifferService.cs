using Lib.Models;

namespace Lib.Services.Interfaces;

public interface ISnifferService
{
    Task<IListPackets> CapturePacketsAsync(INetDevice netDevice, IFilter filter,
        CancellationToken cancellationToken);
}