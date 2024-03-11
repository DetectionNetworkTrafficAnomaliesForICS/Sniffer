﻿using System.ComponentModel;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface ISettingsService
{
    public IFolder? TrafficFolder { get; set; }
    public INetCaptureDevice? NetDevice { get; set; }
}