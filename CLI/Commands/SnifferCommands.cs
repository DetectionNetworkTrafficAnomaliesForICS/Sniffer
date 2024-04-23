using Core.Models;
using Lib.Services.Interfaces;

namespace CLI.Commands;

public class SnifferCommands
{
    private readonly ISnifferService _snifferService;
    private readonly ISettingsService _settingsService;
    private readonly ISaveService _saveService;

    public SnifferCommands(ISnifferService snifferService, ISettingsService settingsService, ISaveService saveService)
    {
        _snifferService = snifferService;
        _settingsService = settingsService;
        _saveService = saveService;
    }

    public void Run()
    {
        if (_settingsService.NetDevice != null)
        {
            var cancelToken = new CancellationTokenSource();


            var taskCapture = _snifferService.CapturePacketsAsync(_settingsService.NetDevice,
                new DeviceFilter(_settingsService.ModbusServers), cancelToken.Token);

            Console.WriteLine("Press `Enter` to finish");
            Console.ReadLine();

            cancelToken.Cancel();

            var packets = taskCapture.Result;

            Console.WriteLine($"{packets.Count()} files intercepted");
            Console.WriteLine("Write a name to save");

            var name = Console.ReadLine();
            if (name != null)
                _saveService.SavePackets(name, packets,
                    (netPacket, modbusPacket) => new CsvPacket(modbusPacket, netPacket)
                    // {
                    //     DateTime = netPacket.DateTime.ToBinary(),
                    //     SrcMacAddress = netPacket.SourceDevice.MacAddress,
                    //     DstMacAddress = netPacket.DestinationDevice.MacAddress,
                    //     CountData = netPacket.Data.Length,
                    //     Data = netPacket.Data.ToArray(),
                    //     Anomaly = modbusPacket.PayloadBytes != null &&
                    //               modbusPacket.Request && BitConverter.ToSingle(modbusPacket.PayloadBytes, 0) > 4.2f
                    // }
                );
        }
        else
        {
            Console.WriteLine("Net Device not selected!");
        }
    }
}