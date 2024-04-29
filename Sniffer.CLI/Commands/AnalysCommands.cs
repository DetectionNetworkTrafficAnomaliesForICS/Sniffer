using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Core.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.CLI.Commands;

public class AnalysisCommands
{
    private readonly ISettingsService _settingsService;
    private readonly IModbusService _modbusService;
    private readonly ModelsConfiguration _modelsConfiguration;
    private readonly AppConfiguration _appConfiguration;
    private readonly IPythonLauncherService _launcherService;

    public AnalysisCommands(ISettingsService settingsService, IOptions<AppConfiguration> aOptions,
        IOptions<ModelsConfiguration> mOptions,
        IPythonLauncherService launcherService, IModbusService modbusService)
    {
        _settingsService = settingsService;
        _modelsConfiguration = mOptions.Value;
        _appConfiguration = aOptions.Value;
        _launcherService = launcherService;
        _modbusService = modbusService;
    }

    public void Run()
    {
        if (_settingsService.NetInterface != null)
        {
            var catcher =
                _settingsService.NetInterface.Open(_appConfiguration.RecheckingCancelTime,
                    _appConfiguration.CapacityPackets);

            var stream = catcher.StartCapture().Filtered(new DeviceFilter(_settingsService.ModbusServers));

            var script = new ModelScript(_modelsConfiguration.Predict, _modelsConfiguration.Models);
            var token = new CancellationTokenSource();

            _launcherService.Launch(_modelsConfiguration.Script, script, token.Token);

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