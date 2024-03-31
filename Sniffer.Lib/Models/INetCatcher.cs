using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sniffer.Lib.Models;

public interface INetCatcher : IDisposable
{
    Task<IListPackets> ReceivePacket(IFilter filter,
        CancellationToken cancellationToken);
}