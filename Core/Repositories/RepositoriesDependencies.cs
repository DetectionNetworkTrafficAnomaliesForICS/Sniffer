using Core.Repositories.Impl;
using Lib.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Repositories;

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