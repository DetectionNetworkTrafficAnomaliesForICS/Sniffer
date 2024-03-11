using System.Collections.Generic;

namespace Sniffer.Lib.Services.Interfaces;

public interface ICsvService
{
    public void WriteCsv<T>(string name, List<T> list);
}