using System.Globalization;
using CsvHelper;
using Lib.Models;
using Lib.Repositories.Interfaces;

namespace Core.Repositories.Impl;

public class CsvRepositoryImpl : ICsvRepository
{
    public bool TryWriteCsvFile<T>(IFile file, IEnumerable<T> list)
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