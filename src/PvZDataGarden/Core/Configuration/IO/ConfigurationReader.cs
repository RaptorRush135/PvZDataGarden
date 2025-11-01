namespace PvZDataGarden.Configuration.IO;

using System.Text.Json;

using MelonLoader;

public static class ConfigurationReader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
    };

    public static IReadOnlyDictionary<TKey, TConfiguration> Read<TKey, TConfiguration>(
        ModFileInfo file)
    {
        Melon<Core>.Logger.Msg($"Reading '{typeof(TConfiguration).Name}' from '{file.Path}'");

        using var stream = file.OpenRead();
        return JsonSerializer.Deserialize<IReadOnlyDictionary<TKey, TConfiguration>>(stream, JsonOptions)
            ?? throw new JsonException("Failed to deserialize JSON into a dictionary. The input may be empty or null.");
    }
}
