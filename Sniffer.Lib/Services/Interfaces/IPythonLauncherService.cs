using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface IPythonLauncherService
{
    void Launch(string command, IScript script, CancellationToken cancellationToken);
}