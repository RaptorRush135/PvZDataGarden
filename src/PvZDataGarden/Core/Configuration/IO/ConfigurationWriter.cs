namespace PvZDataGarden.Configuration.IO;

using System.Text.Json;
using System.Text.Json.Serialization;

using MelonLoader;

public static class ConfigurationWriter
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public static void Write<TKey, TConfiguration>(
        ModFileInfo file,
        IReadOnlyDictionary<TKey, TConfiguration> configurations)
    {
        Melon<Core>.Logger.Msg($"Writing '{typeof(TConfiguration).Name}' to '{file.Path}'");

        using var stream = file.Create();
        JsonSerializer.Serialize(stream, configurations, JsonOptions);
    }
}
