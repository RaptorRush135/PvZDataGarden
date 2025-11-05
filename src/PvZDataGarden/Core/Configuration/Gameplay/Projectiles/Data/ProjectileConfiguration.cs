namespace PvZDataGarden.Configuration.Gameplay.Projectiles.Data;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

public sealed class ProjectileConfiguration : ProjectileConfigurationData
{
    public ProjectileType Type { get; set; }

    public static ProjectileConfiguration FromDefinition(ProjectileDefinition definition)
    {
        return new()
        {
            Type = definition.ProjectileType,
            Damage = definition.Damage,
        };
    }

    public ProjectileConfigurationData AsData() => this;
}
