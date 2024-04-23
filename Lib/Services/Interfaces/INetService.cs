using Lib.Models;

namespace Lib.Services.Interfaces;

public interface INetService
{
    List<INetDevice> GetAll();
}