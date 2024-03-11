using System;
using Sniffer.Lib.Configuration;

namespace Sniffer.Lib.Models;

public interface INetDevice
{
    public NetConfiguration NetConfiguration { get; }
    public INetCatcher Open(int timeout);
    public void Close();
}