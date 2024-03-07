﻿using Microsoft.Extensions.DependencyInjection;
using Sniffer.Core.Services.Impl;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services;

public static class ServicesDependencies
{
    public static void RegisterServicesDependencies(this IServiceCollection services)
    {
        services.AddSingleton<ISettingsService,SettingsServiceImpl>();
        services.AddSingleton<ISnifferService,SnifferServiceImpl>();
        // services.AddSingleton<IDirectoryService,DirectoryServiceImpl>();
        services.AddSingleton<INetService,NetInterfaceServiceImpl>();
    }
}