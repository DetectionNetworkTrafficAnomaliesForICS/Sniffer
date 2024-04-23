using Lib.Models;

namespace Lib.Services.Interfaces;

public interface ISettingsService
{
    IFolder? TrafficFolder { get; set; }
    INetDevice? NetDevice { get; set; }
    IEnumerable<INetPacket.Device> ModbusServers { get; }
}