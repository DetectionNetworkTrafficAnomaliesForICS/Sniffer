using System.Runtime.Serialization.Json;
using System.Threading.Channels;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class ModelScript : IScript
{
    public string[] Arguments { get; } = [];

    public Channel<string> Output { get; } = Channel.CreateUnbounded<string>();
    public Channel<string> Input { get; } = Channel.CreateUnbounded<string>();

    public string Check(CsvPacket packet)
    {
        Input.Writer.WriteAsync($"{packet.SourceIpAddress}---->{packet.DestinationIpAddress}").AsTask();

        return Output.Reader.ReadAsync().AsTask().Result;
    }
}