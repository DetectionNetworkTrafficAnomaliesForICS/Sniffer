using System;
using System.Collections.Generic;
using System.Linq;
using PcapDotNet.Core;
using Sniffer.Core.Models;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public bool TryGet(NetConfiguration config, out INetCaptureDevice? result, INetCaptureDevice? defaultValue = default)
    {
        try
        {
            var allDevices = LivePacketDevice.AllLocalMachine;
            foreach (var device in allDevices)
            {
                if (device.Name.Equals(config.Name))
                {
                    result = new PcapCaptureDevice(device);
                    return true;
                }
            }
        }
        catch (Exception)
        {
            result = defaultValue;
            return false;
        }

        result = defaultValue;
        return false;
    }

    public List<INetCaptureDevice> GetAll()
    {
        var allDevices = LivePacketDevice.AllLocalMachine;
        return allDevices != null
            ? allDevices.Select(device => new PcapCaptureDevice(device)).ToList<INetCaptureDevice>()
            : new List<INetCaptureDevice>();
    }

    public bool TryGetDefault(out INetCaptureDevice? result)
    {
        var allDevices = LivePacketDevice.AllLocalMachine;

        try
        {
            result = new PcapCaptureDevice(allDevices[0]);
            return true;
        }
        catch (Exception)
        {
            result = null;
            return false;
        }
    }
}