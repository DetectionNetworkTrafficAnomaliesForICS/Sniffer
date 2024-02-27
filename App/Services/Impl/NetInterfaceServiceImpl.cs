using Sniffer.Models;
using Sniffer.Repositories;

namespace Sniffer.Services.Impl;

public class NetInterfaceServiceImpl : INetService
{
    private readonly INetInterfaceRepository _interfaceRepository;

    public NetInterfaceServiceImpl(INetInterfaceRepository interfaceRepository)
    {
        _interfaceRepository = interfaceRepository;
    }

    public List<NetInterface> GetAll()
    {
        return _interfaceRepository.GetAll();
    }
}