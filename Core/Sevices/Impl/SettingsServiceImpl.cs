using Core.Configuration;
using Lib.Models;
using Lib.Repositories.Interfaces;
using Lib.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Core.Sevices.Impl;

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

    public INetDevice? NetDevice
    {
        get
        {
            if (_preferenceRepository.TryGet<string>(nameof(NetDevice), out var name))
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
                _preferenceRepository.TrySet(nameof(NetDevice), value.Name);
        }
    }

    public IEnumerable<INetPacket.Device> ModbusServers
    {
        get
        {
            if (_appConfig.Value.ModbusServers == null)
            {
                return new List<INetPacket.Device>();
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