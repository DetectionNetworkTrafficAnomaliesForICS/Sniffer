using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.CLI.Commands;

public class SnifferCommands
{
    private readonly ISnifferService _snifferService;
    private readonly ISettingsService _settingsService;

    public SnifferCommands(ISnifferService snifferService, ISettingsService settingsService)
    {
        _snifferService = snifferService;
        _settingsService = settingsService;
    }

    public void Run()
    {
        if (_settingsService.NetDevice != null)
        {
            var cancelToken = new CancellationTokenSource();
            
            var taskCapture = _snifferService.CapturePacketsAsync(_settingsService.NetDevice, cancelToken.Token);

            Console.WriteLine("Press `Enter` to finish");
            Console.ReadLine();
            
            cancelToken.Cancel();
            
            var packets =  taskCapture.Result;
            packets.ForEach(packet => Console.WriteLine($"{packet.SourceDevice}->{packet.DestinationDevice}"));
            
        }
        else
        {
            Console.WriteLine("Net Device not selected!");
        }
    }
}