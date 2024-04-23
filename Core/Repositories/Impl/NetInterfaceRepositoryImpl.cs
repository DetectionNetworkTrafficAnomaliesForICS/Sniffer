using Core.Models;
using Lib.Models;
using Lib.Repositories.Interfaces;
using PcapDotNet.Core;

namespace Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public bool TryGetByName(string name, out INetDevice? result, INetDevice? defaultValue = default)
    {
        try
        {
            var allDevices = LivePacketDevice.AllLocalMachine;
            foreach (var device in allDevices)
            {
                if (device.Name.Equals(name))
                {
                    result = new PcapDevice(device);
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

    public List<INetDevice> GetAll()
    {
        var allDevices = LivePacketDevice.AllLocalMachine;
        return allDevices != null
            ? allDevices.Select(device => new PcapDevice(device)).ToList<INetDevice>()
            : new List<INetDevice>();
    }
}