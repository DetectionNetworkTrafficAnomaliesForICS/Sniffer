using System.ComponentModel;
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

    public IFolder TrafficFolder
    {
        get
        {
            var config = _preferenceRepository.Get(nameof(TrafficFolder), _directoryRepository.GetDefaultFolder());
            return _directoryRepository.GetByConfiguration(config)!;
        }
        set => _preferenceRepository.Set(nameof(TrafficFolder), value.FolderConfiguration);
    }

    public INetDevice NetDevice
    {
        get
        {
            var config = _preferenceRepository.Get(nameof(NetDevice), _netInterfaceRepository.GetDefault());
            return _netInterfaceRepository.Get(config)!;
        }    
        set => _preferenceRepository.Set(nameof(NetDevice), value?.NetConfiguration);
    }

    public SettingsServiceImpl(INetInterfaceRepository netInterfaceRepository, IDirectoryRepository directoryRepository,
        IPreferenceRepository preferenceRepository)
    {
        _netInterfaceRepository = netInterfaceRepository;
        _directoryRepository = directoryRepository;
        _preferenceRepository = preferenceRepository;
    }
}