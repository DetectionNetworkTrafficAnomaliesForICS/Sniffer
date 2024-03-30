namespace Sniffer.Lib.Models;

public interface IFilter
{
    bool Check(INetPacket packet);
}