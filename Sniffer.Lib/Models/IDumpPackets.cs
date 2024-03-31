using System.Configuration;

namespace Sniffer.Lib.Models;

public interface IDumpPackets
{
    void Save(string pathName);
}