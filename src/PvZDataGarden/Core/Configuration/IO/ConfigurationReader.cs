namespace PvZDataGarden.Configuration.IO;

using System.Text.Json;

using MelonLoader;

using PvZDataGarden.Environment;

public static class ConfigurationReader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
    };

    public static IReadOnlyDictionary<TType, TConfiguration> Read<TType, TConfiguration>(
        ModFileInfo file)
    {
        Melon<Core>.Logger.Msg($"Reading '{typeof(TConfiguration).Name}' from '{file.Path}'");

        using var stream = file.OpenRead();
        return JsonSerializer.Deserialize<IReadOnlyDictionary<TType, TConfiguration>>(stream, JsonOptions)
            ?? throw new JsonException("Failed to deserialize JSON into a dictionary. The input may be empty or null.");
    }
}
