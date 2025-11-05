namespace PvZDataGarden.Configuration.Gameplay.Plants;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration.Gameplay.Plants.Data;
using PvZDataGarden.Configuration.Synchronization;

public sealed class PlantConfigurationSynchronizer(string fileName)
    : ConfigurationSynchronizer<SeedType, PlantDefinition, PlantConfigurationData>(fileName)
{
    private static readonly IReadOnlyCollection<SeedType> IgnoredPlantTypes =
    [
        SeedType.ExplodeONut,
        SeedType.GiantWallnut,
        SeedType.Sprout
    ];

    protected override Dictionary<SeedType, PlantConfigurationData> ExtractConfigurations(
        IEnumerable<PlantDefinition> definitions)
    {
        return definitions
            .Select(PlantConfiguration.FromDefinition)
            .Where(p => !p.IsEmpty && !IgnoredPlantTypes.Contains(p.Type))
            .ToDictionary(p => p.Type, p => p.AsData());
    }
}
