using System.Threading.Channels;

namespace Sniffer.Lib.Services.Interfaces;

public interface IShellLauncherService
{
    public void ExecuteShellCommand(string command, string argument, ChannelReader<string> input,
        ChannelWriter<string> output, CancellationToken cancellationToken);
}