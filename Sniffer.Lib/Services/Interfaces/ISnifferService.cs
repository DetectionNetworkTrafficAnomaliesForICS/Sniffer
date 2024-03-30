using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISnifferService
{
    Task<List<INetPacket>> CapturePacketsAsync(INetDevice netDevice, IFilter filter,
        CancellationToken cancellationToken);
}