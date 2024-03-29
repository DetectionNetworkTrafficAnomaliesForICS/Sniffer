using System;
using Sniffer.Lib.Configuration;

namespace Sniffer.Lib.Models;

public interface INetDevice
{
    NetConfiguration NetConfiguration { get; }
    INetCatcher Open(int timeout);
    void Close();
}