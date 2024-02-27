using System.ComponentModel;
using Sniffer.Models;
using Directory = Sniffer.Models.Directory;

namespace Sniffer.Services;

public interface ISettingsService : INotifyPropertyChanged
{
    public Directory TrafficDirectory { get; set; }
    public NetInterface NetInterface { get; set; }
}