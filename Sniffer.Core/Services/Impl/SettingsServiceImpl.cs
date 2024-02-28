using System.ComponentModel;
using Sniffer.Core.Repositories;
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
    public Folder TrafficFolder
    {
        get => _preferenceRepository.Get(nameof(TrafficFolder), _directoryRepository.GetDefaultDirectory());
        set => _preferenceRepository.Set(nameof(TrafficFolder), value);
    }
    
    public NetInterface NetInterface
    {
        get => _preferenceRepository.Get(nameof(NetInterface), _netInterfaceRepository.GetDefaultGateway());
        set => _preferenceRepository.Set(nameof(NetInterface), value);
    }

    public SettingsServiceImpl(INetInterfaceRepository netInterfaceRepository, IDirectoryRepository directoryRepository,
        IPreferenceRepository preferenceRepository)
    {
        _netInterfaceRepository = netInterfaceRepository;
        _directoryRepository = directoryRepository;
        _preferenceRepository = preferenceRepository;
    }
}