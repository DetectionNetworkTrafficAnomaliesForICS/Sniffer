namespace Sniffer.Lib.Models;

public interface INetCatcher : IDisposable
{
   IStreamPackets StartCapture();
   void StopCapture();
}