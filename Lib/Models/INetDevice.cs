namespace Lib.Models;

public interface INetDevice
{
    string Name { get; }
    INetCatcher Open(int timeout);
    void Close();
}