using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Core.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.CLI.Commands;

public class AnalysisCommands
{
    private readonly ISettingsService _settingsService;
    private readonly IModbusService _modbusService;
    private readonly AppConfiguration _appConfig;
    private readonly IPythonLauncherService _launcherService;

    public AnalysisCommands(ISettingsService settingsService, IOptions<AppConfiguration> options,
        IPythonLauncherService launcherService, IModbusService modbusService)
    {
        _settingsService = settingsService;
        _appConfig = options.Value;
        _launcherService = launcherService;
        _modbusService = modbusService;
    }

    public void Run()
    {
        if (_settingsService.NetInterface != null)
        {
            var catcher =
                _settingsService.NetInterface.Open(_appConfig.RecheckingCancelTime, _appConfig.CapacityPackets);

            var stream = catcher.StartCapture().Filtered(new DeviceFilter(_settingsService.ModbusServers));

            var script = new ModelScript("C:\\Users\\rodio\\PycharmProjects\\ML-Diploma\\experiments\\data.pickle");
            var token = new CancellationTokenSource();
          
            _launcherService.Launch(_appConfig.Script, script, token.Token);

            stream.Foreach(packet =>
            {
                if (_modbusService.TryConvertToModbusPacket(packet, out var modbus))
                {
                    Console.WriteLine(script.Check(new CsvPacket(modbus!, packet)));
                }
            });

            Console.WriteLine("Press `Enter` to finish");

            Console.ReadLine();

            catcher.StopCapture();
            _settingsService.NetInterface.Close();
            
            token.Cancel();
             
        }
    }
}