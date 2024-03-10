using System.Collections.Generic;
using Sniffer.Lib.Models;

namespace Sniffer.Lib.Services.Interfaces;

public interface INetService
{
    List<INetCaptureDevice> GetAll();
}