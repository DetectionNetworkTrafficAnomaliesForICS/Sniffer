using Sniffer.Lib.Models;

namespace Sniffer.Core.Configuration;

public class AppConfiguration
{
    public required int RecheckingCancelTime { get; init; }
    public required int CapacityPackets { get; init; }
    public required NetConfiguration? DefaultNetDevice { get; init; }
    public required FolderConfiguration? DefaultFolder { get; init; }
    public required IEnumerable<INetPacket.Device>? ModbusServers { get; init; }
}