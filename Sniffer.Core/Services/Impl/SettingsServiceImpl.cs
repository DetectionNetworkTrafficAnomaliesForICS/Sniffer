using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class SettingsServiceImpl : ISettingsService
{
    private readonly INetInterfaceRepository _netInterfaceRepository;
    private readonly IFolderRepository _folderRepository;
    private readonly IPreferenceRepository _preferenceRepository;
    private readonly IOptions<AppConfiguration> _appConfig;

    public IFolder? TrafficFolder
    {
        get
        {
            if (_preferenceRepository.TryGet<FolderConfiguration>(nameof(TrafficFolder), out var config))
            {
                _folderRepository.TryGetByConfiguration(config!, out var folder);
                return folder;
            }

            if (_appConfig.Value.DefaultFolder != null)
            {
                _folderRepository.TryGetByConfiguration(_appConfig.Value.DefaultFolder, out var folderDefault);
                return folderDefault;
            }

            return default;
        }
        set
        {
            if (value != null)
                _preferenceRepository.TrySet(nameof(TrafficFolder), value.FolderConfiguration);
        }
    }

    public INetCaptureDevice? NetDevice
    {
        get
        {
            if (_preferenceRepository.TryGet<NetConfiguration>(nameof(NetDevice), out var config))
            {
                _netInterfaceRepository.TryGet(config!, out var device);
                return device;
            }

            if (_appConfig.Value.DefaultNetDevice != null)
            {
                _netInterfaceRepository.TryGet(_appConfig.Value.DefaultNetDevice, out var deviceDefault);
                return deviceDefault;
            }

            return default;
        }
        set
        {
            if (value != null)
                _preferenceRepository.TrySet(nameof(NetDevice), value.NetConfiguration);
        }
    }

    public SettingsServiceImpl(INetInterfaceRepository netInterfaceRepository, IFolderRepository folderRepository,
        IPreferenceRepository preferenceRepository, IOptions<AppConfiguration> appConfig)
    {
        _netInterfaceRepository = netInterfaceRepository;
        _folderRepository = folderRepository;
        _preferenceRepository = preferenceRepository;
        _appConfig = appConfig;
    }
}