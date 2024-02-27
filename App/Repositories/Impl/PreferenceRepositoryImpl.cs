using System.Text.Json;

namespace Sniffer.Repositories.Impl;

public class PreferenceRepositoryImpl : IPreferenceRepository
{
    public void Set<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        Preferences.Default.Set(key, json);
    }

    public T Get<T>(string key, T defValue)
    {
        var json = Preferences.Default.Get(key, string.Empty);
        return json.Equals(string.Empty) ? defValue : JsonSerializer.Deserialize<T>(json);
    }
}