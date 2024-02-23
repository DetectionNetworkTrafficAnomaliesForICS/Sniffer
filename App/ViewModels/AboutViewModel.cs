namespace Sniffer.ViewModels;

public class AboutViewModel: AViewModel
{
    public string Version => VersionTracking.CurrentVersion;
    
}