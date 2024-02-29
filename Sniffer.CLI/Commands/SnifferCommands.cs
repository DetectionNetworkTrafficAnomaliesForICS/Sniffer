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
        var packets =_snifferService.CapturePackets(_settingsService.NetDevice);
        packets.ForEach(packet => Console.WriteLine($"{packet.SourceDevice}->{packet.DestinationDevice}"));
    }
}