namespace Sniffer.Lib.Models;

public interface INetInterface
{
    string Name { get; }
    INetCatcher Open(int timeout, int capacity);
    void Close();
}