using System.Threading.Tasks;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface IDirectoryService
{
    Task<IFolder> PickDirectory();
}