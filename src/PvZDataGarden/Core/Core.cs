namespace PvZDataGarden;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;
using Il2CppReloaded.Services;

using MelonLoader;

using PvZDataGarden.Api;
using PvZDataGarden.Configuration.Gameplay.Projectiles;
using PvZDataGarden.Configuration.Gameplay.SeedPackets;
using PvZDataGarden.Configuration.Gameplay.Zombies;
using PvZDataGarden.Configuration.Synchronization;
using PvZDataGarden.Extensions;

public sealed class Core : MelonMod
{
    private static readonly IReadOnlyCollection<IConfigurationSynchronizationDescriptor> Configurations =
    [
        new ConfigurationSynchronizationDescriptor<SeedType, PlantDefinition>(
            new SeedPacketConfigurationSynchronizer("packets.json"),
            s => s.PlantDefinitions.AsEnumerable(),
            s => s.GetPlantDefinition),
        new ConfigurationSynchronizationDescriptor<ZombieType, ZombieDefinition>(
            new ZombieConfigurationSynchronizer("zombies.json"),
            s => s.ZombieDefinitions.AsEnumerable(),
            s => s.GetZombieDefinition),
        new ConfigurationSynchronizationDescriptor<ProjectileType, ProjectileDefinition>(
            new ProjectileConfigurationSynchronizer("projectiles.json"),
            s => s.ProjectileDefinitions.AsEnumerable(),
            s => s.GetProjectileDefinition),
    ];

    public override void OnInitializeMelon()
    {
        DataServiceApi.OnReady.Subscribe(OnDataServiceReady);
    }

    private static void OnDataServiceReady(IDataService dataService)
    {
        Melon<Core>.Logger.WriteSpacer();

        foreach (var config in Configurations)
        {
            try
            {
                if (!config.HasCollected)
                {
                    config.Collect(dataService);
                    continue;
                }

                config.Patch(dataService);
            }
            catch (Exception ex)
            {
                Melon<Core>.Logger.Error($"Error synchronizing '{config.DefinitionTypeName}'", ex);
            }
            finally
            {
                Melon<Core>.Logger.WriteSpacer();
            }
        }
    }
}
