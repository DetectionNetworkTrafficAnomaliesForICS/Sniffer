using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Sniffer.Lib.Repositories.Interfaces;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class CsvServiceImpl : ICsvService
{
    private readonly ICsvRepository _csvRepository;
    private readonly ISettingsService _settingsService;
    private readonly IFolderRepository _folderRepository;
    
    public CsvServiceImpl(ICsvRepository csvRepository, ISettingsService settingsService,
        IFolderRepository folderRepository)
    {
        _csvRepository = csvRepository;
        _settingsService = settingsService;
        _folderRepository = folderRepository;
    }


    public void WriteCsv<T>(string name, List<T> list)
    {
        if (_settingsService.TrafficFolder == null) return;
        if (_folderRepository.TryCreateFile(_settingsService.TrafficFolder, name, out var file))
            _csvRepository.TryWriteCsvFile(file!, list);
    }
}