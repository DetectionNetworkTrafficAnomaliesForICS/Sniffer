using Sniffer.Lib.Configuration;

namespace Sniffer.Lib.Models;

public interface INetCaptureDevice : INetCapture, IDisposable
{
    public NetConfiguration NetConfiguration { get; }
}