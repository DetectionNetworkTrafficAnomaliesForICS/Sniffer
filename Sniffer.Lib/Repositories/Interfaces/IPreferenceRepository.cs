namespace Sniffer.Lib.Repositories.Interfaces;

public interface IPreferenceRepository
{
    public bool TrySet<T>(string key, T value) where T : class;
    public bool TryGet<T>(string key, out T? result, T? defaultValue = default) where T : class;
}