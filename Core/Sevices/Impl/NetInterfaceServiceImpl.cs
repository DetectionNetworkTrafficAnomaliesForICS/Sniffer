using Lib.Models;
using Lib.Repositories.Interfaces;
using Lib.Services.Interfaces;

namespace Core.Sevices.Impl;

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