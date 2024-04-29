using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Channels;
using CsvHelper;
using CsvHelper.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class ModelScript : IScript
{
    private string Predict { get; }
    
    private string Model { get; }

    public string[] Arguments { get; }

    public Channel<string> Output { get; } = Channel.CreateUnbounded<string>();
    public Channel<string> Input { get; } = Channel.CreateUnbounded<string>();

    public ModelScript(string predict, string model)
    {
        Predict = predict;
        Model = model;
        Arguments = [Predict, Model];
    }

    public string Check(CsvPacket packet)
    {
        using var writer = new StringWriter();
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };
        using var csv = new CsvWriter(writer, config);

        csv.WriteRecords([packet]);
        writer.Flush();

        Input.Writer.WriteAsync(writer.ToString()).AsTask();

        return Output.Reader.ReadAsync().AsTask().Result;
    }
}