namespace Sniffer.Core.Configuration;

public class AppConfiguration
{
    public int RecheckingCancelTime { get; set; }
    public NetConfiguration? DefaultNetDevice { get; set; }
    public FolderConfiguration? DefaultFolder { get; set; }
}