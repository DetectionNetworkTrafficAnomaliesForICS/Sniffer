namespace Sniffer.Lib.Models;

public interface INetDevice
{
    string Name { get; }
    INetCatcher Open(int timeout, int capacity);
    void Close();
}