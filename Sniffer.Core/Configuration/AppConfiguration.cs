using Sniffer.Core.Models;

namespace Sniffer.Core.Configuration;

public class AppConfiguration
{
    public required int RecheckingCancelTime { get; init; }
    public required int CapacityPackets { get; init; }
    public required string Python { get; init; }
}