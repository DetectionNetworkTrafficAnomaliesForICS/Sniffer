using System.Collections.Generic;
using System.Text.Json;
using Sniffer.Lib.Repositories.Interfaces;

namespace Sniffer.Core.Repositories.Impl;

public class PreferenceRepositoryImpl : IPreferenceRepository
{
    private readonly Dictionary<string, string> _dictionary = new();

    public bool TrySet<T>(string key, T value) where T : class
    {
        try
        {
            var json = JsonSerializer.Serialize(value);

            _dictionary[key] = json;

            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    public bool TryGet<T>(string key, out T? result, T? defaultValue = default) where T : class
    {
        if (_dictionary.TryGetValue(key, out var json))
        {
            try
            {
                result = JsonSerializer.Deserialize<T>(json);
                return true;
            }
            catch (JsonException)
            {
                result = defaultValue;
                return false;
            }
        }

        result = defaultValue;
        return false;
    }
}