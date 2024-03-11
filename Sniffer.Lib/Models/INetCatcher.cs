using System;
using System.Threading;

namespace Sniffer.Lib.Models;

public interface INetCatcher: IDisposable
{
    ReceiveResult ReceivePacket(out INetPacket? packet);
    
    enum ReceiveResult
    {
        Ok,
        Timeout,
        Error
    }
}
