namespace Sniffer.Core.Configuration;

public class NetConfiguration
{
    public string Name { get; }

    public NetConfiguration(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}