using Sniffer.Lib.Configuration;

namespace Sniffer.Core.Configuration;

public class AppConfiguration
{
    public int RecheckingCancelTime { get; set; }
    public NetConfiguration? DefaultNetDevice { get; set; }
}