using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class PythonLauncherServiceImpl : IPythonLauncherService
{
    private readonly IShellLauncherService _launcherService;
    private readonly AppConfiguration _appConfig;

    public PythonLauncherServiceImpl(IShellLauncherService launcherService, IOptions<AppConfiguration> _options)
    {
        _appConfig = _options.Value;
        _launcherService = launcherService;
    }

    public void Launch(string command, IScript script, CancellationToken cancellationToken)
    {
        var processArgs = $"{command} {string.Join(" ", script.Arguments)}";
        _launcherService.ExecuteShellCommand(_appConfig.Python, processArgs, script.Input, script.Output,
            cancellationToken);
    }
}