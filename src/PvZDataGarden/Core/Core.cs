namespace PvZDataGarden;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;
using Il2CppReloaded.Services;

using MelonLoader;

using PvZDataGarden.Api;
using PvZDataGarden.Configuration.Gameplay.Plants;
using PvZDataGarden.Configuration.Gameplay.Projectiles;
using PvZDataGarden.Configuration.Synchronization;
using PvZDataGarden.Extensions;

public sealed class Core : MelonMod
{
    private static readonly IReadOnlyCollection<IConfigurationSynchronizationDescriptor> Configurations =
    [
        new ConfigurationSynchronizationDescriptor<SeedType, PlantDefinition>(
            new PlantConfigurationSynchronizer("plants.json"),
            s => s.PlantDefinitions.AsEnumerable(),
            s => s.GetPlantDefinition),
        new ConfigurationSynchronizationDescriptor<ProjectileType, ProjectileDefinition>(
            new ProjectileConfigurationSynchronizer("projectiles.json"),
            s => s.ProjectileDefinitions.AsEnumerable(),
            s => s.GetProjectileDefinition),
    ];

    public override void OnInitializeMelon()
    {
        DataServiceApi.OnReady += OnDataServiceReady;
    }

    private static void OnDataServiceReady(IDataService dataService)
    {
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
        }
    }
}
