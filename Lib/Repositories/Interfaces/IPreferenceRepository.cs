namespace Lib.Repositories.Interfaces;

public interface IPreferenceRepository
{
    bool TrySet<T>(string key, T value) where T : class;
    bool TryGet<T>(string key, out T? result, T? defaultValue = default) where T : class;
}