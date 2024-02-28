using System.Text.Json;

namespace Sniffer.Core.Repositories.Impl;

public class PreferenceRepositoryImpl : IPreferenceRepository
{
    private readonly Dictionary<string, string> _dictionary = new();

    public void Set<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        _dictionary[key] = json;
    }

    public T Get<T>(string key, T defValue)
    {
        if (_dictionary.TryGetValue(key, out var json))
        {
            return JsonSerializer.Deserialize<T>(json) ?? defValue;
        }

        return defValue;
    }
}