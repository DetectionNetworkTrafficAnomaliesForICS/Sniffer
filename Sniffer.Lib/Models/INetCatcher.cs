namespace Sniffer.Lib.Models;

public interface INetCatcher : IDisposable
{
   IStreamPackets StreamPackets { get; }
   void Capture(CancellationToken cancellationToken);
}