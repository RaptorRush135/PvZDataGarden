namespace PvZDataGarden.Configuration.Gameplay.Projectiles.Data;

using Il2CppReloaded.Data;

public class ProjectileConfigurationData : IConfigurationData<ProjectileDefinition>
{
    public int? Damage { get; set; }

    public void Patch(ProjectileDefinition definition)
    {
        definition.m_damage = this.Damage ?? definition.m_damage;
    }
}
