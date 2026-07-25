namespace PvZDataGarden.Configuration.Gameplay.SeedPackets;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration.Gameplay.SeedPackets.Data;
using PvZDataGarden.Configuration.Synchronization;

public sealed class SeedPacketConfigurationSynchronizer(string fileName)
    : ConfigurationSynchronizer<SeedType, PlantDefinition, SeedPacketConfigurationData>(fileName)
{
    private static readonly IReadOnlyCollection<SeedType> IgnoredPlantTypes =
    [
        SeedType.ExplodeONut,
        SeedType.GiantWallnut,
        SeedType.Sprout,
    ];

    protected override Dictionary<SeedType, SeedPacketConfigurationData> ExtractConfigurations(
        IEnumerable<PlantDefinition> definitions)
    {
        return definitions
            .Select(SeedPacketConfiguration.FromDefinition)
            .Where(p => !p.IsEmpty && !IgnoredPlantTypes.Contains(p.Type))
            .ToDictionary(p => p.Type, p => p.AsData());
    }
}
