using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class CsvRepositoryImpl : ICsvRepository
{
    public bool TryWriteCsvFile<T>(IFile file, List<T> list)
    {
        try
        {
            using var writer = file.Writer;
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(list);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}