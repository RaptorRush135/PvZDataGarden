namespace PvZDataGarden.Configuration.Gameplay.Plants.Data;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using Il2CppSource.Controllers;

using PvZDataGarden.Unity;

using UnityEngine;

public sealed record PlantConfiguration : PlantConfigurationData
{
    public SeedType Type { get; set; }

    public static PlantConfiguration FromDefinition(PlantDefinition definition)
    {
        var health = GetHealth(definition);

        return new PlantConfiguration()
        {
            Type = definition.SeedType,
            Health = health,
            Versus = PlantVersusConfiguration.Create(health),
        };
    }

    public PlantConfigurationData AsData() => this;

    private static int GetHealth(PlantDefinition definition)
    {
        var plant = GetDummyPlant(definition);
        return plant.mPlantHealth;
    }

    private static Plant GetDummyPlant(PlantDefinition definition)
    {
        var prefabInstance = PrefabCloner.InstantiateFromPrefabAsset(definition.m_prefab, expectLoaded: true);

        var controller = prefabInstance.GetComponent<PlantController>();

        try
        {
            var plant = new Plant();

            controller.Init(plant);

            plant.PlantInitialize(0, 0, definition.SeedType, SeedType.None, controller);

            return plant;
        }
        finally
        {
            Object.Destroy(prefabInstance);
        }
    }
}
