using Microsoft.Extensions.DependencyInjection;
using Sniffer.Core.Repositories.Impl;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories;

public static class RepositoriesDependencies
{
    public static void RegisterRepositoriesDependencies(this IServiceCollection services)
    {
        services.AddSingleton<INetInterfaceRepository,NetInterfaceRepositoryImpl>();
        services.AddSingleton<ICsvRepository, CsvRepositoryImpl>();
        services.AddSingleton<IFolderRepository,FolderRepositoryImpl>();
        services.AddSingleton<IPreferenceRepository,PreferenceRepositoryImpl>();
    }
}