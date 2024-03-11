using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Sniffer.Core.Models;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class CsvServiceImpl : ICsvService
{
    private readonly ICsvRepository _csvRepository;
    private readonly ISettingsService _settingsService;
    private readonly IFolderRepository _folderRepository;
    private readonly IModbusService _modbusService;

    public CsvServiceImpl(ICsvRepository csvRepository, ISettingsService settingsService,
        IFolderRepository folderRepository, IModbusService modbusService)
    {
        _csvRepository = csvRepository;
        _settingsService = settingsService;
        _folderRepository = folderRepository;
        _modbusService = modbusService;
    }

    public void WriteModbusPackets(string name, List<INetPacket> list)
    {
        if (_settingsService.TrafficFolder == null) return;
        if (_folderRepository.TryCreateFile(_settingsService.TrafficFolder, name, out var file))
        {
            var result = new List<CsvPacket>();
            foreach (var packet in list)
            {
                if (_modbusService.TryConvertToModbusPacket(packet, out var modbus))
                {
                    result.Add(new CsvPacket(modbus!, packet));
                }
            }

            _csvRepository.TryWriteCsvFile(file!, result);
        }
    }
}