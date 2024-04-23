using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISnifferService
{
    Task<IListPackets> CapturePacketsAsync(INetDevice netDevice, IFilter filter,
        CancellationToken cancellationToken);
}