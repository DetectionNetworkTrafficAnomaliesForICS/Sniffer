using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISnifferService
{
    public Task<List<INetPacket>> CapturePacketsAsync(INetCapture netDeviceCapture,
        CancellationToken cancellationToken);
}