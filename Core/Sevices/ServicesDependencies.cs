using Core.Sevices.Impl;
using Lib.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Sevices;

public static class ServicesDependencies
{
    public static void RegisterServicesDependencies(this IServiceCollection services)
    {
        services.AddSingleton<ISettingsService, SettingsServiceImpl>();
        services.AddSingleton<ISnifferService, SnifferServiceImpl>();
        services.AddSingleton<IModbusService, ModbusServiceImpl>();
        services.AddSingleton<INetService, NetInterfaceServiceImpl>();
        services.AddSingleton<ISaveService, SaveServiceImpl>();
    }
}