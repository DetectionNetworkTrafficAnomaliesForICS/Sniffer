using System;
using System.Threading;
using Sniffer.Core.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.CLI.Commands;

public class SnifferCommands
{
    private readonly ISnifferService _snifferService;
    private readonly ISettingsService _settingsService;
    private readonly ICsvService _csvService;

    public SnifferCommands(ISnifferService snifferService, ISettingsService settingsService, ICsvService csvService)
    {
        _snifferService = snifferService;
        _settingsService = settingsService;
        _csvService = csvService;
    }

    public void Run()
    {
        if (_settingsService.NetDevice != null)
        {
            var cancelToken = new CancellationTokenSource();


            var taskCapture = _snifferService.CapturePacketsAsync(_settingsService.NetDevice,
                new DeviceFilter(_settingsService.FilteredDevice), cancelToken.Token);

            Console.WriteLine("Press `Enter` to finish");
            Console.ReadLine();

            cancelToken.Cancel();

            var packets = taskCapture.Result;

            Console.WriteLine($"{packets.Count} files intercepted");
            Console.WriteLine("Write a name to save");

            var name = Console.ReadLine();
            if (name != null) _csvService.WriteModbusPackets(name, packets);
        }
        else
        {
            Console.WriteLine("Net Device not selected!");
        }
    }
}