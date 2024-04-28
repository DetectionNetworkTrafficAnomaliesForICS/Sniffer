using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Core.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.CLI.Commands;

public class SnifferCommands
{
    private readonly AppConfiguration _appConfig;
    private readonly ISettingsService _settingsService;
    private readonly ISaveService _saveService;

    public SnifferCommands(ISettingsService settingsService,IOptions<AppConfiguration> appConfig, ISaveService saveService)
    {
        _settingsService = settingsService;
        _saveService = saveService;
        _appConfig = appConfig.Value;
    }

    public void Run()
    {
        if (_settingsService.NetDevice != null)
        {
            var catcher = _settingsService.NetDevice.Open(_appConfig.RecheckingCancelTime, _appConfig.CapacityPackets);
 
            var stream = catcher.StartCapture().Filtered(new DeviceFilter(_settingsService.ModbusServers));
            
            Console.WriteLine("Press `Enter` to finish");
            Console.ReadLine();

            catcher.StopCapture();

            var packets = stream.ToList().Result;

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
            
            _settingsService.NetDevice.Close();
        }
        else
        {
            Console.WriteLine("Net Device not selected!");
        }
    }
}