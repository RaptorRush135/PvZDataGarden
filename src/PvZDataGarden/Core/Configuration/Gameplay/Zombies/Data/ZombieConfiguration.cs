namespace PvZDataGarden.Configuration.Gameplay.Zombies.Data;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using Il2CppSource.Controllers;

using PvZDataGarden.Extensions;
using PvZDataGarden.Unity;

using UnityEngine;

public sealed record ZombieConfiguration : ZombieConfigurationData
{
    public ZombieType Type { get; set; }

    public static ZombieConfiguration FromDefinition(ZombieDefinition definition)
    {
        var health = GetHealth(definition);

        return new ZombieConfiguration()
        {
            Type = definition.ZombieType,
            Health = health,
            Versus = ZombieVersusConfiguration.Create(
                    definition.VersusBodyHealth,
                    definition.VersusArmorHealth),
        };
    }

    public ZombieConfigurationData AsData() => this;

    private static ZombieHealth GetHealth(ZombieDefinition definition)
    {
        var zombie = GetDummyZombie(definition);

        return new()
        {
            Body = zombie.mBodyHealth.NullIfDefault(),
            Helmet = zombie.mHelmHealth.NullIfDefault(),
            Shield = zombie.mShieldHealth.NullIfDefault(),
            Flying = zombie.mFlyingHealth.NullIfDefault(),
        };
    }

    private static Zombie GetDummyZombie(ZombieDefinition definition)
    {
        var prefabInstance = PrefabCloner.InstantiateFromPrefabAsset(definition.Prefab, expectLoaded: true);

        var controller = prefabInstance.GetComponent<ZombieController>();

        try
        {
            var zombie = new Zombie();

            controller.Init(zombie);

            zombie.ZombieInitialize(
                0, definition.ZombieType, false, null, Il2CppReloaded.Constants.Zombie.ZOMBIE_WAVE_UI, controller);

            return zombie;
        }
        finally
        {
            Object.Destroy(prefabInstance);
        }
    }
}
