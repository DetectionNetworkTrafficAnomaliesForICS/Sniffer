using System;
using System.Collections.Generic;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class SaveServiceImpl : ISaveService
{
    private readonly ICsvRepository _csvRepository;
    private readonly ISettingsService _settingsService;
    private readonly IFolderRepository _folderRepository;
    private readonly IModbusService _modbusService;

    public SaveServiceImpl(ICsvRepository csvRepository, ISettingsService settingsService,
        IFolderRepository folderRepository, IModbusService modbusService)
    {
        _csvRepository = csvRepository;
        _settingsService = settingsService;
        _folderRepository = folderRepository;
        _modbusService = modbusService;
    }

    public void SavePackets<T>(string name, IEnumerable<INetPacket> list, Func<INetPacket, IModbusPacket, T> fun)
    {
        if (_settingsService.TrafficFolder == null) return;
        if (_folderRepository.TryCreateFile(_settingsService.TrafficFolder, name, out var file))
        {
            var result = new List<T>();
            foreach (var packet in list)
            {
                if (_modbusService.TryConvertToModbusPacket(packet, out var modbus))
                {
                    result.Add(fun(packet, modbus!));
                }
            }

            _csvRepository.TryWriteCsvFile(file!, result);
        }
    }
}