namespace PvZDataGarden.Configuration.Gameplay.Projectiles;

using System.Collections.Generic;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration.Gameplay.Projectiles.Data;
using PvZDataGarden.Configuration.Synchronization;

public sealed class ProjectileConfigurationSynchronizer(string fileName)
    : ConfigurationSynchronizer<ProjectileType, ProjectileDefinition, ProjectileConfigurationData>(fileName)
{
    protected override Dictionary<ProjectileType, ProjectileConfigurationData> ExtractConfigurations(
        IEnumerable<ProjectileDefinition> definitions)
    {
        return definitions
            .Select(ProjectileConfiguration.FromDefinition)
            .ToDictionary(p => p.Type, p => p.AsData());
    }
}
