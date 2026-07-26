namespace PvZDataGarden.Configuration.Gameplay.Plants.Data;

using Il2CppReloaded.Gameplay;

public sealed record PlantVersusConfiguration
{
    public int? Health { get; set; }

    public static PlantVersusConfiguration Create(int health)
    {
        return new()
        {
            Health = health,
        };
    }

    public void Apply(Plant plant)
    {
        if (this.Health.HasValue)
        {
            plant.mPlantHealth = this.Health.Value;
        }
    }
}
