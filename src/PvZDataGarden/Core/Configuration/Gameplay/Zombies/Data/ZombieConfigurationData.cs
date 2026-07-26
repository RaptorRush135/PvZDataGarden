namespace PvZDataGarden.Configuration.Gameplay.Zombies.Data;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

public record ZombieConfigurationData : IConfigurationData<ZombieDefinition>
{
    public ZombieHealth? Health { get; set; }

    public ZombieVersusConfiguration? Versus { get; set; }

    public void Patch(ZombieDefinition definition)
    {
        // Nothing to patch
    }

    public void Apply(Zombie zombie)
    {
        this.Health?.Apply(zombie);
        this.Versus?.Apply(zombie);
    }
}
