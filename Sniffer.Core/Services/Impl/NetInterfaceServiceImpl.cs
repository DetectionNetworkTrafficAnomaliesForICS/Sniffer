using System.Collections.Generic;
using Sniffer.Lib.Models;
using Sniffer.Lib.Repositories.Interfaces;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class NetInterfaceServiceImpl : INetService
{
    private readonly INetInterfaceRepository _interfaceRepository;

    public NetInterfaceServiceImpl(INetInterfaceRepository interfaceRepository)
    {
        _interfaceRepository = interfaceRepository;
    }

    public List<INetDevice> GetAll()
    {
        return _interfaceRepository.GetAll();
    }
}