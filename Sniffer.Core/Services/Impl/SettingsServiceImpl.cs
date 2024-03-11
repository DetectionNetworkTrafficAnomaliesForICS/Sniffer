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

    public IFolder? TrafficFolder
    {
        get
        {
            _preferenceRepository.TryGet<FolderConfiguration>(nameof(TrafficFolder), out var config);
            if (config != null)
            {
                _folderRepository.TryGetByConfiguration(config, out var folder);
                return folder;
            }

            _folderRepository.TryGetDefaultFolder(out var folderDefault);
            return folderDefault;
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

    public SettingsServiceImpl(INetInterfaceRepository netInterfaceRepository, IFolderRepository folderRepository,
        IPreferenceRepository preferenceRepository)
    {
        _netInterfaceRepository = netInterfaceRepository;
        _folderRepository = folderRepository;
        _preferenceRepository = preferenceRepository;
    }
}