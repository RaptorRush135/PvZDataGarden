namespace PvZDataGarden.Configuration.Gameplay.Plants;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration.Gameplay.Plants.Data;
using PvZDataGarden.Configuration.Gameplay.Plants.Patches;
using PvZDataGarden.Configuration.Synchronization;

public sealed class PlantConfigurationSynchronizer(string fileName)
    : ConfigurationSynchronizer<SeedType, PlantDefinition, PlantConfigurationData>(fileName)
{
    protected override void Patch(
        Func<SeedType, PlantDefinition> definitionProvider,
        IReadOnlyDictionary<SeedType, PlantConfigurationData> configurations)
    {
        PlantInitializePatch.Overrides = configurations;
        LogPatchedCount(configurations.Count);
    }

    protected override Dictionary<SeedType, PlantConfigurationData> ExtractConfigurations(
        IEnumerable<PlantDefinition> definitions)
    {
        return definitions
            .Where(p => p.SeedType is (>= SeedType.Peashooter and <= SeedType.Imitater) or SeedType.Leftpeater)
            .Select(PlantConfiguration.FromDefinition)
            .ToDictionary(p => p.Type, p => p.AsData());
    }
}
