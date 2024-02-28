﻿using System.ComponentModel;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISettingsService : INotifyPropertyChanged
{
    public Folder TrafficFolder { get; set; }
    public NetInterface? NetInterface { get; set; }
}