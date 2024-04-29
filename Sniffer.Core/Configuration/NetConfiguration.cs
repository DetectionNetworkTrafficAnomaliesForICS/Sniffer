using Sniffer.Core.Models;

namespace Sniffer.Core.Configuration;

public class NetConfiguration
{
    public required string Name { get; init; }
    public required IEnumerable<NetDevice> ModbusServers { get; init; }
}