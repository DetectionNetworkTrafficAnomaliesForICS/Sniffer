using System.Net.NetworkInformation;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class NetInterfaceRepositoryImpl : INetInterfaceRepository
{
    public List<NetInterface> GetAll()
    {
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        return networkInterfaces.Select(networkInterface => new NetInterface(networkInterface.Name)).ToList();
    }

    public NetInterface GetDefaultGateway()
    {
        foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (networkInterface.OperationalStatus == OperationalStatus.Up)
            {
                var ipProperties = networkInterface.GetIPProperties();
                var gateways = ipProperties.GatewayAddresses;

                if (gateways.Count > 0)
                {
                    return new NetInterface(networkInterface.Name);
                }
            }
        }

        return null;
    }


    public NetInterface GetLoopback()
    {
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (var networkInterface in networkInterfaces)
        {
            if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback)
            {
                return new NetInterface(networkInterface.Name);
            }
        }

        return null;
    }
}