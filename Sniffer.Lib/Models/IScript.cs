using System.Threading.Channels;

namespace Sniffer.Lib.Models;

public interface IScript
{
    string[] Arguments { get; }
    Channel<string> Output { get; }
    Channel<string> Input { get; }
}