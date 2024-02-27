using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Sniffer.Repositories;
using Sniffer.Repositories.Impl;
using Sniffer.Services;
using Sniffer.Services.Impl;
using Sniffer.View.Pages;
using Sniffer.ViewModels;

namespace Sniffer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var services = builder.Services;

        builder
            .UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        _AddRepositories(services);
        _AddServices(services);
        _AddPageAndViewModelServices(services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void _AddServices(IServiceCollection services)
    {
        services.AddSingleton<ISettingsService,SettingsServiceImpl>();
        services.AddSingleton<IDirectoryService,DirectoryServiceImpl>();
        services.AddSingleton<INetService,NetInterfaceServiceImpl>();
    }

    private static void _AddRepositories(IServiceCollection services)
    {
        services.AddSingleton<INetInterfaceRepository,NetInterfaceRepositoryImpl>();
        services.AddSingleton<IDirectoryRepository,DirectoryRepositoryImpl>();
        services.AddSingleton<IPreferenceRepository,PreferenceRepositoryImpl>();
    }

    private static void _AddPageAndViewModelServices(IServiceCollection services)
    {
        services.AddSingleton<AboutPage>();
        services.AddSingleton<AboutViewModel>();
        
        services.AddSingleton<SettingPage>();
        services.AddSingleton<SettingViewModel>();
        
        services.AddSingleton<HomePage>();
        services.AddSingleton<HomeViewModel>();
    }
}