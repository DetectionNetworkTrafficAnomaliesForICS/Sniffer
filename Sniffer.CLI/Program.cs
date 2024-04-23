using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sniffer.CLI.Commands;
using Sniffer.Core.Configuration;
using Sniffer.Core.Repositories;
using Sniffer.Core.Services;

namespace Sniffer.CLI;

internal static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.Configure<AppConfiguration>(hostContext.Configuration.GetSection(nameof(AppConfiguration)));
                services.AddHostedService<MainWorker>();
                services.RegisterServicesDependencies();
                services.RegisterRepositoriesDependencies();
                services.AddSingleton<SettingCommands>();
                services.AddSingleton<SnifferCommands>();
            });
    }
}