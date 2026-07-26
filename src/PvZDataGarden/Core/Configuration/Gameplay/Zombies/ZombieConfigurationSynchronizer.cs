namespace PvZDataGarden.Configuration.Gameplay.Zombies;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration.Gameplay.Zombies.Data;
using PvZDataGarden.Configuration.Gameplay.Zombies.Patches;
using PvZDataGarden.Configuration.Synchronization;

public sealed class ZombieConfigurationSynchronizer(string fileName)
    : ConfigurationSynchronizer<ZombieType, ZombieDefinition, ZombieConfigurationData>(fileName)
{
    private static readonly IReadOnlyCollection<ZombieType> IgnoredZombieTypes =
    [
        ZombieType.DuckyTube,
        ZombieType.PeaHead,
        ZombieType.WallnutHead,
        ZombieType.JalapenoHead,
        ZombieType.GatlingHead,
        ZombieType.SquashHead,
        ZombieType.TallnutHead,
        ZombieType.Zombatar,
    ];

    protected override void Patch(
        Func<ZombieType, ZombieDefinition> definitionProvider,
        IReadOnlyDictionary<ZombieType, ZombieConfigurationData> configurations)
    {
        ZombieInitializePatch.Overrides = configurations;
        LogPatchedCount(configurations.Count);
    }

    protected override Dictionary<ZombieType, ZombieConfigurationData> ExtractConfigurations(
        IEnumerable<ZombieDefinition> definitions)
    {
        return definitions
            .Where(d => !IgnoredZombieTypes.Contains(d.ZombieType))
            .Select(ZombieConfiguration.FromDefinition)
            .ToDictionary(d => d.Type, d => d.AsData());
    }
}
