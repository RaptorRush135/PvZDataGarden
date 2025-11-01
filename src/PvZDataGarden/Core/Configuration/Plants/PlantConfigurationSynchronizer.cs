namespace PvZDataGarden.Configuration.Plants;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using MelonLoader;

using PvZDataGarden.Configuration;
using PvZDataGarden.Configuration.IO;
using PvZDataGarden.Configuration.Plants.Data;
using PvZDataGarden.Environment;
using PvZDataGarden.Extensions;

public sealed class PlantConfigurationSynchronizer
    : IConfigurationSynchronizer<SeedType, PlantDefinition>
{
    private readonly ModFileInfo targetFile = ModEnvironment.GetFile(PlantConfigurationData.DefaultFileName);

    public bool HasCollected => this.targetFile.Exists;

    public void Collect(IEnumerable<PlantDefinition> definitions)
    {
        IReadOnlyDictionary<SeedType, PlantConfigurationData> configurations = definitions
            .Select(PlantConfiguration.FromDefinition)
            .Where(p => !p.IsEmpty)
            .ToDictionary(p => p.Type, p => p.AsData())
            .ToSorted();

        ConfigurationWriter.Write(
            this.targetFile,
            configurations);
    }

    public void Patch(Func<SeedType, PlantDefinition> definitionProvider)
    {
        var configurations = ConfigurationReader.Read<SeedType, PlantConfigurationData>(this.targetFile);
        foreach (var (type, configuration) in configurations)
        {
            PlantDefinition definition = definitionProvider.Invoke(type);
            configuration.Patch(definition);
        }

        Melon<Core>.Logger.Msg($"Patched {configurations.Count} {nameof(PlantDefinition)}s");
    }
}
