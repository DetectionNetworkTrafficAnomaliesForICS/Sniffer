using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Sniffer.Models;
using Sniffer.Repositories;
using Directory = Sniffer.Models.Directory;

namespace Sniffer.Services.Impl;

public sealed class SettingsServiceImpl : ISettingsService
{
    private readonly INetInterfaceRepository _netInterfaceRepository;
    private readonly IDirectoryRepository _directoryRepository;
    private readonly IPreferenceRepository _preferenceRepository;

    public event PropertyChangedEventHandler PropertyChanged;

    public Directory TrafficDirectory
    {
        get => _preferenceRepository.Get(nameof(TrafficDirectory), _directoryRepository.GetDefaultDirectory());
        set => _preferenceRepository.Set(nameof(TrafficDirectory), value);
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