namespace Lib.Models;

public interface INetCatcher : IDisposable
{
    Task<IListPackets> ReceivePacket(IFilter filter,
        CancellationToken cancellationToken);
}