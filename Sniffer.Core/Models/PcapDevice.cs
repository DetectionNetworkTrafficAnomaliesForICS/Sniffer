﻿using SharpPcap;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapDevice : INetDevice
{
    private readonly ICaptureDevice _captureDevice;
    public string Name => _captureDevice.Name;

    public PcapDevice(ICaptureDevice captureDevice)
    {
        _captureDevice = captureDevice;
    }

    public INetCatcher Open(int timeout, int capacity)
    {
        _captureDevice.Open(DeviceModes.Promiscuous, timeout);
        
        return new PcapNetCatcher(_captureDevice,
            capacity);
    }

    public void Close()
    {
        _captureDevice.Close();
    }

    public override string ToString()
    {
        return _captureDevice.Description;
    }
}