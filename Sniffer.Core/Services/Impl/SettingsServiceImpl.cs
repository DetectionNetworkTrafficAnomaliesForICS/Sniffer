using System.ComponentModel;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class SettingsServiceImpl : ISettingsService
{
    private readonly INetInterfaceRepository _netInterfaceRepository;
    private readonly IDirectoryRepository _directoryRepository;
    private readonly IPreferenceRepository _preferenceRepository;

    public event PropertyChangedEventHandler? PropertyChanged;

    public IFolder? TrafficFolder
    {
        get
        {
            _preferenceRepository.TryGet<FolderConfiguration>(nameof(TrafficFolder), out var config);
            if (config != null)
            {
                _directoryRepository.TryGetByConfiguration(config, out var folder);
                return folder;
            }

            _directoryRepository.TryGetDefaultFolder(out var folderDefault);
            return folderDefault;
        }
        set
        {
            if (value != null)
                _preferenceRepository.TrySet(nameof(TrafficFolder), value.FolderConfiguration);
        }
    }

    public INetDevice? NetDevice
    {
        get
        {
            _preferenceRepository.TryGet<NetConfiguration>(nameof(NetDevice), out var config);
            if (config != null)
            {
                _netInterfaceRepository.TryGet(config, out var device);
                return device;
            }

            _netInterfaceRepository.TryGetDefault(out var deviceDefault);
            return deviceDefault;
        }
        set
        {
            if (value != null)
                _preferenceRepository.TrySet(nameof(NetDevice), value.NetConfiguration);
        }
    }

    public SettingsServiceImpl(INetInterfaceRepository netInterfaceRepository, IDirectoryRepository directoryRepository,
        IPreferenceRepository preferenceRepository)
    {
        _netInterfaceRepository = netInterfaceRepository;
        _directoryRepository = directoryRepository;
        _preferenceRepository = preferenceRepository;
    }
}