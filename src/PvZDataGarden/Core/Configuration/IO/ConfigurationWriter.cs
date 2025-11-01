namespace PvZDataGarden.Configuration.IO;

using System.Text.Json;
using System.Text.Json.Serialization;

public static class ConfigurationWriter
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public static void Write<TKey, TConfiguration>(
        string path,
        IReadOnlyDictionary<TKey, TConfiguration> configurations)
    {
        using var stream = File.Create(path);
        Write(stream, configurations);
    }

    public static void Write<TKey, TConfiguration>(
        Stream stream,
        IReadOnlyDictionary<TKey, TConfiguration> configurations)
    {
        JsonSerializer.Serialize(stream, configurations, JsonOptions);
    }
}
