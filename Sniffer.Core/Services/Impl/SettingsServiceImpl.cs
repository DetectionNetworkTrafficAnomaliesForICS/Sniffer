using Microsoft.Extensions.Options;
using Sniffer.Core.Configuration;
using Sniffer.Core.Models;
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
            if (_preferenceRepository.TryGet<string>(nameof(TrafficFolder), out var path))
            {
                _folderRepository.TryGetByPath(path!, out var folder);
                return folder;
            }

            if (_appConfig.Value.DefaultFolder != null)
            {
                _folderRepository.TryGetByPath(_appConfig.Value.DefaultFolder.Path, out var folderDefault);
                return folderDefault;
            }

            return default;
        }
        set
        {
            if (value != null)
                _preferenceRepository.TrySet(nameof(TrafficFolder), value.Path);
        }
    }

    public INetInterface? NetInterface
    {
        get
        {
            if (_preferenceRepository.TryGet<string>(nameof(NetInterface), out var name))
            {
                _netInterfaceRepository.TryGetByName(name!, out var device);
                return device;
            }

            if (_appConfig.Value.DefaultNetDevice != null)
            {
                _netInterfaceRepository.TryGetByName(_appConfig.Value.DefaultNetDevice.Name, out var deviceDefault);
                return deviceDefault;
            }

            return default;
        }
        set
        {
            if (value != null)
                _preferenceRepository.TrySet(nameof(NetInterface), value.Name);
        }
    }

    public IEnumerable<INetDevice> ModbusServers
    {
        get
        {
            if (_appConfig.Value.ModbusServers == null)
            {
                return new List<NetDevice>();
            }

            return _appConfig.Value.ModbusServers;
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