using System.Collections.Generic;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Repositories.Interfaces;

public interface INetInterfaceRepository
{
    bool TryGet(NetConfiguration config, out INetCaptureDevice? result, INetCaptureDevice? defaultValue = default);
    List<INetCaptureDevice> GetAll();
    bool TryGetDefault(out INetCaptureDevice? result);
}