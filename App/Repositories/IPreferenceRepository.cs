namespace Sniffer.Repositories;

public interface IPreferenceRepository
{
    public void Set<T>(string key, T value);
    public T Get<T>(string key, T defValue);
}