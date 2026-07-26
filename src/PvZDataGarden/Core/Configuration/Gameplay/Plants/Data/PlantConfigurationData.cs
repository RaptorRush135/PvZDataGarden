namespace PvZDataGarden.Configuration.Gameplay.Plants.Data;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

public record PlantConfigurationData : IConfigurationData<PlantDefinition>
{
    public int? Health { get; set; }

    public PlantVersusConfiguration? Versus { get; set; }

    public void Patch(PlantDefinition definition)
    {
        // Nothing to patch
    }

    public void Apply(Plant plant, bool isVersus)
    {
        if (!isVersus)
        {
            if (this.Health.HasValue)
            {
                plant.mPlantHealth = this.Health.Value;
            }
        }
        else
        {
            this.Versus?.Apply(plant);
        }

        plant.mPlantMaxHealth = plant.mPlantHealth;
    }
}
