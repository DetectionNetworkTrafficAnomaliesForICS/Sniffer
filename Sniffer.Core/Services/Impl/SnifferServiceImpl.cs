using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;


namespace Sniffer.Core.Services.Impl;

public class SnifferServiceImpl : ISnifferService
{
    public List<INetPacket> CapturePackets(INetDevice netDevice)
    {
        var packets = new List<INetPacket>();

        using var device = netDevice;

        device.Open();

        device.OnPacketArrival += (_, packet) =>
        {
            packets.Add(packet);
        };
        
        device.Start();
        Console.ReadLine();

        return packets;
    }

 
}